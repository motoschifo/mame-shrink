#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MameTools.Machine;
using MameTools.Net48.Common;
using MameTools.Net48.Config;
using MameTools.Net48.Extensions;
using MameTools.Net48.Machines.Samples;
using MameTools.Net48.SoftwareList;

namespace MameTools.Net48;

public class Mame
{
    public MameMachineCollection Machines { get; private set; } = [];
    public MameSoftwareListCollection SoftwareLists { get; private set; } = [];
    public MameSoftwareListCollection SoftwareListHashes { get; private set; } = [];
    public List<Sample> MachineSamples { get; private set; } = [];


    private string? _build;         // 0.264 (mame0264)
    public string? Build
    {
        get => _build;
        set
        {
            _build = value ?? string.Empty;
            _release = string.Empty;
            _releaseNumber = string.Empty;
            var s = _build;
            if (s.StartsWith("MAME"))
                s = s.Substring("MAME".Length).Trim();
            var pos = s!.IndexOf(' ');
            if (pos > 0)
                _release = s.SafeSubstring(0, pos);

            pos = _release!.IndexOf('.');
            if (pos > 0)
                _releaseNumber = _release.SafeSubstring(pos + 1);

            _releaseSequence = GetSequenceFromRelease(_release);
        }
    }

    private string? _release;       // 0.264
    public string? Release => _release;

    private string? _releaseNumber;  // 264
    public string? ReleaseNumber => _releaseNumber;

    private decimal _releaseSequence;  // 0.100u4 --> 100.04m
    public decimal ReleaseSequence => _releaseSequence;

    private bool _debug;
    public bool Debug { get => _debug; set => _debug = value; }

    private string? _mameConfig;
    public string? MameConfig { get => _mameConfig; set => _mameConfig = value; }

    private static readonly Dictionary<string, decimal> _specialReleases = new()
    {
        { "0.8.1", 8.01m },            { "0.9.1", 9.01m },            { "0.21.5", 21.05m },               { "0.23.1", 23.01m },
        { "0.26a", 26.01m },           { "0.33b1", 33.01m },          { "0.33b2", 33.02m },               { "0.33b3", 33.03m },
        { "0.33b4", 33.04m },          { "0.33b5", 33.05m },          { "0.33b6", 33.06m },               { "0.33b7", 33.07m },
        { "0.33rc1", 33.08m },         { "0.34b1", 34.01m },          { "0.34b2", 34.02m },               { "0.34b3", 34.03m },
        { "0.34b4", 34.04m },          { "0.34b5", 34.05m },          { "0.34b6", 34.06m },               { "0.34b7", 34.07m },
        { "0.34b8", 34.08m },          { "0.34rc1", 34.9m },          { "0.34rc2", 34.10m },              { "0.35b1", 35.01m },
        { "0.35b2", 35.02m },          { "0.35b3", 35.03m },          { "0.35b4", 35.04m },               { "0.35b5", 35.05m },
        { "0.35b6", 35.06m },          { "0.35b7", 35.07m },          { "0.35b8", 35.08m },               { "0.35b9", 35.09m },
        { "0.35b10", 35.10m },         { "0.35b11", 35.11m },         { "0.35b12", 35.12m },              { "0.35b13", 35.13m },
        { "0.35rc1", 35.14m },         { "0.35rc2", 35.15m },         { "0.35(fixed)", 35.16m },          { "0.36b1", 36.01m },
        { "0.36b2", 36.02m },          { "0.36b3", 36.03m },          { "0.36b4", 36.04m },               { "0.36b5", 36.05m },
        { "0.36b6", 36.06m },          { "0.36b7", 36.07m },          { "0.36b8", 36.08m },               { "0.36b9", 36.09m },
        { "0.36b9.1", 36.10m },        { "0.36b10", 36.11m },         { "0.36b11", 36.12m },              { "0.36b12", 36.13m },
        { "0.36b13", 36.14m },         { "0.36b14", 36.15m },         { "0.36b15", 36.16m },              { "0.36b16", 36.17m },
        { "0.36rc1", 36.18m },         { "0.36rc2", 36.19m },         { "0.37b1(0.37)", 37.01m },         { "0.37b2(0.38)", 37.02m },
        { "0.37b3(0.39)", 37.03m },    { "0.37b4(0.40)", 37.04m },    { "0.37b5(0.41)", 37.05m },         { "0.37b6(0.42)", 37.06m },
        { "0.37b7(0.43)", 37.07m },    { "0.37b8(0.44)", 37.08m },    { "0.37b9(0.45)", 37.09m },         { "0.37b10(0.46)", 37.10m },
        { "0.37b11(0.47)", 37.11m },   { "0.37b12(0.48)", 37.12m },   { "0.37b12fixed(0.48)", 37.13m },   { "0.37b13(0.49)", 37.14m },
        { "0.37b14(0.50)", 37.15m },   { "0.37b15(0.51)", 37.16m },   { "0.37b16(0.52)", 37.17m },        { "0.69a", 69.01m },
        { "0.69b", 69.02m },           { "0.69u3", 69.03m },          { "0.70u1", 70.01m },               { "0.70u2", 70.02m },
        { "0.70u3", 70.03m },          { "0.70u4", 70.04m },          { "0.70u5", 70.05m },               { "0.71u1", 71.01m },
        { "0.71u2", 71.02m },          { "0.71u3p", 71.03m },         { "0.72u1", 72.01m },               { "0.72u2", 72.02m },
        { "0.74u1", 74.01m },          { "0.74u2", 74.02m },          { "0.75u1", 75.01m },               { "0.76u1", 76.01m },
        { "0.76u2", 76.02m },          { "0.77u1", 77.01m },          { "0.77u2", 77.02m },               { "0.77u3", 77.03m },
        { "0.78u1", 78.01m },          { "0.78u2", 78.02m },          { "0.78u3", 78.03m },               { "0.78u4", 78.04m },
        { "0.78u5", 78.05m },          { "0.78u6", 78.06m },          { "0.79u1", 79.01m },               { "0.79u2", 79.02m },
        { "0.79u3", 79.03m },          { "0.79u4", 79.04m },          { "0.80u1", 80.01m },               { "0.80u2", 80.02m },
        { "0.80u3", 80.03m },          { "0.81u1", 81.01m },          { "0.81u2", 81.02m },               { "0.81u3", 81.03m },
        { "0.81u4", 81.04m },          { "0.81u5", 81.05m },          { "0.81u6", 81.06m },               { "0.81u7", 81.07m },
        { "0.81u8", 81.08m },          { "0.81u9", 81.09m },          { "0.82u1", 82.01m },               { "0.82u2", 82.02m },
        { "0.82u3", 82.03m },          { "0.84u1", 84.01m },          { "0.84u2", 84.02m },               { "0.84u3", 84.03m },
        { "0.84u4", 84.04m },          { "0.84u5", 84.05m },          { "0.84u6", 84.06m },               { "0.85u1", 85.01m },
        { "0.85u2", 85.02m },          { "0.85u3", 85.03m },          { "0.86u1", 86.01m },               { "0.86u2", 86.02m },
        { "0.86u3", 86.03m },          { "0.86u4", 86.04m },          { "0.86u5", 86.05m },               { "0.87u1", 87.01m },
        { "0.87u2", 87.02m },          { "0.87u3", 87.03m },          { "0.87u4", 87.04m },               { "0.88u1", 88.01m },
        { "0.88u2", 88.02m },          { "0.88u3", 88.03m },          { "0.88u4", 88.04m },               { "0.88u5", 88.05m },
        { "0.88u6", 88.06m },          { "0.88u7", 88.07m },          { "0.89u1", 89.01m },               { "0.89u2", 89.02m },
        { "0.89u3", 89.03m },          { "0.89u4", 89.04m },          { "0.89u5", 89.05m },               { "0.89u6", 89.06m },
        { "0.90u1", 90.01m },          { "0.90u2", 90.02m },          { "0.90u3", 90.03m },               { "0.90u4", 90.04m },
        { "0.91u1", 91.01m },          { "0.91u2", 91.02m },          { "0.92u1", 92.01m },               { "0.93u1", 93.01m },
        { "0.93u2", 93.02m },          { "0.93u3", 93.03m },          { "0.94u1", 94.01m },               { "0.94u2", 94.02m },
        { "0.94u3", 94.03m },          { "0.94u4", 94.04m },          { "0.94u5", 94.05m },               { "0.95u1", 95.01m },
        { "0.95u2", 95.02m },          { "0.95u3", 95.03m },          { "0.95u4", 95.04m },               { "0.95u5", 95.05m },
        { "0.95u6", 95.06m },          { "0.96u1", 96.01m },          { "0.96u2", 96.02m },               { "0.96u3", 96.03m },
        { "0.96u4", 96.04m },          { "0.97u1", 97.01m },          { "0.97u2", 97.02m },               { "0.97u3", 97.03m },
        { "0.97u4", 97.04m },          { "0.97u5", 97.05m },          { "0.98u1", 98.01m },               { "0.98u2", 98.02m },
        { "0.98u3", 98.03m },          { "0.98u4", 98.04m },          { "0.99u1", 99.01m },               { "0.99u2", 99.02m },
        { "0.99u3", 99.03m },          { "0.99u4", 99.04m },          { "0.99u5", 99.05m },               { "0.99u6", 99.06m },
        { "0.99u7", 99.07m },          { "0.99u8", 99.08m },          { "0.99u9", 99.09m },               { "0.99u10", 99.10m },
        { "0.100u1", 100.01m },        { "0.100u2", 100.02m },        { "0.100u3", 100.03m },             { "0.100u4", 100.04m },
        { "0.101u1", 101.01m },        { "0.101u2", 101.02m },        { "0.101u3", 101.03m },             { "0.101u4", 101.04m },
        { "0.101u5", 101.05m },        { "0.102u1", 102.01m },        { "0.102u2", 102.02m },             { "0.102u3", 102.03m },
        { "0.102u4", 102.04m },        { "0.102u5", 102.05m },        { "0.103u1", 103.01m },             { "0.103u2", 103.02m },
        { "0.103u3", 103.03m },        { "0.103u4", 103.04m },        { "0.103u5", 103.05m },             { "0.104u1", 104.01m },
        { "0.104u2", 104.02m },        { "0.104u3", 104.03m },        { "0.104u4", 104.04m },             { "0.104u5", 104.05m },
        { "0.104u6", 104.06m },        { "0.104u7", 104.07m },        { "0.104u8", 104.08m },             { "0.104u9", 104.09m },
        { "0.105u1", 105.01m },        { "0.105u2", 105.02m },        { "0.105u3", 105.03m },             { "0.105u4", 105.04m },
        { "0.105u5", 105.05m },        { "0.106u1", 106.01m },        { "0.106u2", 106.02m },             { "0.106u3", 106.03m },
        { "0.106u4", 106.04m },        { "0.106u5", 106.05m },        { "0.106u6", 106.06m },             { "0.106u7", 106.07m },
        { "0.106u8", 106.08m },        { "0.106u9", 106.09m },        { "0.106u10", 106.10m },            { "0.106u11", 106.11m },
        { "0.106u12", 106.12m },       { "0.106u13", 106.13m },       { "0.107u1", 107.01m },             { "0.107u2", 107.02m },
        { "0.107u3", 107.03m },        { "0.107u4", 107.04m },        { "0.108u1", 107.01m },             { "0.108u2", 107.02m },
        { "0.108u3", 107.03m },        { "0.108u4", 107.04m },        { "0.108u5", 107.05m },             { "0.109u1", 107.01m },
        { "0.109u2", 107.02m },        { "0.109u3", 107.03m },        { "0.109u4", 107.04m },             { "0.109u5", 107.05m },
        { "0.110u1", 110.01m },        { "0.110u2", 110.02m },        { "0.110u3", 110.03m },             { "0.110u4", 110.04m },
        { "0.110u5", 110.05m },        { "0.111u1", 111.01m },        { "0.111u2", 111.02m },             { "0.111u3", 111.03m },
        { "0.111u4", 111.04m },        { "0.111u5", 111.05m },        { "0.111u6", 111.06m },             { "0.112u1", 112.01m },
        { "0.112u2", 112.02m },        { "0.112u3", 112.03m },        { "0.112u4", 112.04m },             { "0.113u1", 113.01m },
        { "0.113u2", 113.02m },        { "0.113u3", 113.03m },        { "0.113u4", 113.04m },             { "0.114u1", 114.01m },
        { "0.114u2", 114.02m },        { "0.114u3", 114.03m },        { "0.114u4", 114.04m },             { "0.115u1", 115.01m },
        { "0.115u2", 115.02m },        { "0.115u3", 115.03m },        { "0.115u4", 115.04m },             { "0.116u1", 116.01m },
        { "0.116u2", 116.02m },        { "0.116u3", 116.03m },        { "0.116u4", 116.04m },             { "0.117u1", 117.01m },
        { "0.117u2", 117.02m },        { "0.117u3", 117.03m },        { "0.118u1", 118.01m },             { "0.118u2", 118.02m },
        { "0.118u3", 118.03m },        { "0.118u4", 118.04m },        { "0.118u5", 118.05m },             { "0.118u6", 118.06m },
        { "0.119u1", 119.01m },        { "0.119u2", 119.02m },        { "0.119u3", 119.03m },             { "0.119u4", 119.04m },
        { "0.120u1", 120.01m },        { "0.120u2", 120.02m },        { "0.120u3", 120.03m },             { "0.120u4", 120.04m },
        { "0.121u1", 121.01m },        { "0.121u2", 121.02m },        { "0.121u3", 121.03m },             { "0.121u4", 121.04m },
        { "0.122u1", 122.01m },        { "0.122u2", 122.02m },        { "0.122u3", 122.03m },             { "0.122u4", 122.04m },
        { "0.122u5", 122.05m },        { "0.122u6", 122.06m },        { "0.122u7", 122.07m },             { "0.122u8", 122.08m },
        { "0.123u1", 123.01m },        { "0.123u2", 123.02m },        { "0.123u3", 123.03m },             { "0.123u4", 123.04m },
        { "0.123u5", 123.05m },        { "0.123u6", 123.06m },        { "0.124a", 124.01m },              { "0.124u1", 124.02m },
        { "0.124u2", 124.03m },        { "0.124u3", 124.04m },        { "0.124u4", 124.05m },             { "0.124u5", 124.06m },
        { "0.125u1", 125.01m },        { "0.125u2", 125.02m },        { "0.125u3", 125.03m },             { "0.125u4", 125.04m },
        { "0.125u5", 125.05m },        { "0.125u6", 125.06m },        { "0.125u7", 125.07m },             { "0.125u8", 125.08m },
        { "0.125u9", 125.09m },        { "0.126u1", 126.01m },        { "0.126u2", 126.02m },             { "0.126u3", 126.03m },
        { "0.126u4", 126.04m },        { "0.126u5", 126.05m },        { "0.127u1", 127.01m },             { "0.127u2", 127.02m },
        { "0.127u3", 127.03m },        { "0.127u4", 127.04m },        { "0.127u5", 127.05m },             { "0.127u6", 127.06m },
        { "0.127u7", 127.07m },        { "0.127u8", 127.08m },        { "0.128u1", 128.01m },             { "0.128u2", 128.02m },
        { "0.128u3", 128.03m },        { "0.128u4", 128.04m },        { "0.128u5", 128.05m },             { "0.128u6", 128.06m },
        { "0.128u7", 128.07m },        { "0.129u1", 129.01m },        { "0.129u2", 129.02m },             { "0.129u3", 129.03m },
        { "0.129u4", 129.04m },        { "0.129u5", 129.05m },        { "0.129u6", 129.06m },             { "0.130u1", 130.01m },
        { "0.130u2", 130.02m },        { "0.130u3", 130.03m },        { "0.130u4", 130.04m },             { "0.131u1", 131.01m },
        { "0.131u2", 131.02m },        { "0.131u3", 131.03m },        { "0.131u4", 131.04m },             { "0.132u1", 132.01m },
        { "0.132u2", 132.02m },        { "0.132u3", 132.03m },        { "0.132u4", 132.04m },             { "0.132u5", 132.05m },
        { "0.133u1", 133.01m },        { "0.133u2", 133.02m },        { "0.133u3", 133.03m },             { "0.133u4", 133.04m },
        { "0.133u5", 133.05m },        { "0.134u1", 134.01m },        { "0.134u2", 134.02m },             { "0.134u3", 134.03m },
        { "0.134u4", 134.04m },        { "0.135u1", 135.01m },        { "0.135u2", 135.02m },             { "0.135u3", 135.03m },
        { "0.135u4", 135.04m },        { "0.136u1", 136.01m },        { "0.136u2", 136.02m },             { "0.136u3", 136.03m },
        { "0.136u4", 136.04m },        { "0.137u1", 137.01m },        { "0.137u2", 137.02m },             { "0.137u3", 137.03m },
        { "0.137u4", 137.04m },        { "0.138u1", 138.01m },        { "0.138u2", 138.02m },             { "0.138u3", 138.03m },
        { "0.138u4", 138.04m },        { "0.139u1", 139.01m },        { "0.139u2", 139.02m },             { "0.139u3", 139.03m },
        { "0.139u4", 139.04m },        { "0.140u1", 140.01m },        { "0.140u2", 140.02m },             { "0.140u3", 140.03m },
        { "0.141u1", 141.01m },        { "0.141u2", 141.02m },        { "0.141u3", 141.03m },             { "0.141u4", 141.04m },
        { "0.142u1", 142.01m },        { "0.142u2", 142.02m },        { "0.142u3", 142.03m },             { "0.142u4", 142.04m },
        { "0.142u5", 142.05m },        { "0.142u6", 142.06m },        { "0.143u1", 143.01m },             { "0.143u2", 143.02m },
        { "0.143u3", 143.03m },        { "0.143u4", 143.04m },        { "0.143u5", 143.05m },             { "0.143u6", 143.06m },
        { "0.143u7", 143.07m },        { "0.143u8", 143.08m },        { "0.143u9", 143.09m },             { "0.144u1", 144.01m },
        { "0.144u2", 144.02m },        { "0.144u3", 144.03m },        { "0.144u4", 144.04m },             { "0.144u5", 144.05m },
        { "0.144u6", 144.06m },        { "0.144u7", 144.07m },        { "0.145u1", 145.01m },             { "0.145u2", 145.02m },
        { "0.145u3", 145.03m },        { "0.145u4", 145.04m },        { "0.145u5", 145.05m },             { "0.145u6", 145.06m },
        { "0.145u7", 145.07m },        { "0.145u8", 145.08m },        { "0.146u1", 146.01m },             { "0.146u2", 146.02m },
        { "0.146u3", 146.03m },        { "0.146u4", 146.04m },        { "0.146u5", 146.05m },             { "0.147u1", 147.01m },
        { "0.147u2", 147.02m },        { "0.147u3", 147.03m },        { "0.147u4", 147.04m },             { "0.148u1", 148.01m },
        { "0.148u2", 148.02m },        { "0.148u3", 148.03m },        { "0.148u4", 148.04m },             { "0.148u5", 148.05m },
        { "0.149u1", 149.01m },
    };

    public static decimal ReleaseSequence34 => _releaseSequence34;
    private static decimal _releaseSequence34;
    public static decimal ReleaseSequence84u6 => _releaseSequence84u6;
    private static decimal _releaseSequence84u6;
    public static decimal ReleaseSequence69b => _releaseSequence69b;
    private static decimal _releaseSequence69b;
    public static decimal ReleaseSequence100u3 => _releaseSequence100u3;
    private static decimal _releaseSequence100u3;
    public static decimal ReleaseSequence117u1 => _releaseSequence117u1;
    private static decimal _releaseSequence117u1;




    public static decimal GetSequenceFromRelease(string? release)
    {
        if (string.IsNullOrEmpty(release))
            return 0;
        if (_specialReleases.TryGetValue(release!, out var specialValue))
            return specialValue;
        if (decimal.TryParse(release, out var value))
            return value;
        return 0;
    }


    public Mame()
    {
        _releaseSequence34 = GetSequenceFromRelease("0.34");
        _releaseSequence84u6 = GetSequenceFromRelease("0.84u6");
        _releaseSequence69b = GetSequenceFromRelease("0.69b");
        _releaseSequence100u3 = GetSequenceFromRelease("0.100u3");
        _releaseSequence117u1 = GetSequenceFromRelease("0.117u1");
    }

    public MameCounterWithDelta OrphansSoftwareLists { get; } = new("orphan SL");

    public MameCounterWithDelta OrphansSoftware { get; } = new("orphan software");

    public void RefreshSpecialTotals(Action<string?>? progressUpdate = null)
    {
        var index = 0;
        var total = SoftwareListHashes.Count + (_releaseSequence > 0 ? 2 : 0);

        // Aggiorno i totali che non possono essere calcolati in altro modo, se non su richiesta del chiamante

        // Samples
        Machines.Totals.SamplePacks.ResetCount();
        var samplesMachines = Machines.Where(x => x.UseSample).ToList();
        Machines.Totals.SamplePacks.IncrementCount([.. samplesMachines.Select(x => x.SampleOf).Distinct()]);

        Machines.Totals.SampleFiles.ResetCount();
        //var sampleFiles = new List<string>();
        var clonesProcessed = new List<string>();
        foreach (var machine in samplesMachines.OrderBy(x => x.SampleOf))
        {
            if (clonesProcessed.Contains(machine.SampleOf!)) continue;
            Machines.Totals.SampleFiles.IncrementCount([.. machine.Samples.Select(x => $"{machine.Samples};{x}")]);
            clonesProcessed.Add(machine.SampleOf!);
            //sampleFiles.AddRange(machine.Samples);
        }

        //OrphansSoftware.ResetCount();
        //foreach (MameSoftwareList softListHash in SoftwareListHashes)
        //{
        //    index++;
        //    progressUpdate?.Invoke($"{Convert.ToInt32(index * 100.0 / total)}%");
        //    var sl = SoftwareLists.FirstOrDefault(x => x.Name == softListHash.Name);
        //    if (sl is null)
        //        OrphansSoftware.IncrementCount(softListHash.Software.Select(x => x.Name).ToList());
        //    else
        //        OrphansSoftware.IncrementCount(softListHash.Software.Where(x => !sl.Software.Any(y => y.Name == x.Name)).Select(x => x.Name).ToList());
        //}

        OrphansSoftwareLists.ResetCount();
        OrphansSoftware.ResetCount();
        //OrphansSoftwareLists.IncrementCount(SoftwareListHashes.Where(x => !SoftwareLists.Any(y => y.Name == x.Name)).Select(x => x.Name).ToList());
        foreach (SoftwareList.MameSoftwareList listHash in SoftwareListHashes)
        {
            index++;
            progressUpdate?.Invoke($"{Convert.ToInt32(index * 100.0 / total)}%");

            SoftwareList.MameSoftwareList? listXml = SoftwareLists.FirstOrDefault(x => x.Name == listHash.Name);
            if (listXml is null)
            {
                // Lista non trovata: aggiungo tutti i software come orfani
                OrphansSoftwareLists.IncrementCount(listHash.Name);
                OrphansSoftware.IncrementCount([.. listHash.Software.Select(x => $"{listHash.Name}/{x.Name}")]);
            }
            else
            {
                var soft = listHash.Software.Where(x => !listXml.Software.Any(y => y.Name == x.Name)).ToList();
                if (soft.Count == 0) continue;
                OrphansSoftware.IncrementCount([.. soft.Select(x => $"{listXml.Name}/{x.Name}")]);
                //// Controllo i software nelle due liste
                //foreach (var softHash in listHash.Software)
                //{
                //    var softXml = listXml!.Software.FirstOrDefault(x => x.Name == softHash.Name);
                //    if (softXml is null) continue;
                //    OrphansSoftware.IncrementCount(softHash.Name);
                //}
            }
        }

        // Fix in base alla release
        if (_releaseSequence > 0)
        {
            // L'attributo "savestate" fino alla versione 0.100u4 non è presente, quindi dalla versione 0.1 alla 0.100u3
            // devono obbligatoriamente essere conteggiate tutte le macchine come "save unsupported", esattamente come per le
            // macchine mechanical/not mechanicals
            index++;
            progressUpdate?.Invoke($"{Convert.ToInt32(index * 100.0 / total)}%");
            if (_releaseSequence <= _releaseSequence100u3)
            {
                Machines.Totals.SaveSupported.ResetCount();
                Machines.Totals.SaveUnsupported.SetCount(Machines.Totals.Machines.Count);
                Machines.Totals.Mechanicals.ResetCount();
                Machines.Totals.NotMechanicals.SetCount(Machines.Totals.Machines.Count);
            }

            // Fino alla versione 0.117u1 l'attributo "isbios" non è presente
            // Dalla versione 0.34 alla 0.84u6 si contano le occorrenze isbios="yes" (e le relative rom).
            // Dalla versione 0.69b alla 0.117u1 si contano, per ogni versione, quante ricorrenze ci sono di runnable="no" (e relative rom).
            //index++;
            //progressUpdate?.Invoke($"{Convert.ToInt32(index * 100.0 / total)}%");
            //if (_releaseSequence >= _releaseSequence69b && _releaseSequence <= _releaseSequence117u1)
            //{
            //    var totalBioses = 0;
            //    var totalBiosesRoms = 0;
            //    foreach (var machine in Machines.Where(x => !x.IsRunnable))
            //    {
            //        machine.IsBios = true;
            //        totalBioses++;
            //        totalBiosesRoms += machine.Roms.Count;
            //    }
            //    Machines.Totals.Bioses.SetCount(totalBioses);
            //    Machines.Totals.BiosRoms.SetCount(totalBiosesRoms);
            //}
        }
    }

    public string GetTotalsTextLines(string? releaseId = null, DateTime? releaseDate = null)
    {
        var sb = new StringBuilder();
        if (Machines.Any())
        {
            // Riga 1
            // 46.750 total items, 3.005 drivers(+8), 40.309 machines(+34), 13.841 parents(+17), 26.544 clones(+17), 76 BIOSes, 6.365 devices(-1 / +22), 1.195 requires CHDs(+1), 1.862 use samples(+22)
            _ = sb
                .Append(Machines.Totals.Items)
                .Append(";").Append(Machines.Totals.Drivers)
                .Append(";").Append(Machines.Totals.Machines)
                .Append(";").Append(Machines.Totals.Parents)
                .Append(";").Append(Machines.Totals.Clones)
                .Append(";").Append(Machines.Totals.Bioses)
                .Append(";").Append(Machines.Totals.Devices)
                .Append(";").Append(Machines.Totals.RequiresDisks)
                .Append(";").Append(Machines.Totals.UseSamples)
                .AppendLine();
            // Riga 2
            // 15.378 working(+23), 25.007 not working(+11), 15.618 mechanicals(+1), 24.767 not mechanicals(+33), 13.859 save supported(+14), 26.526 save unsupported(+20), 37.180 horizontal screen(+28), 3.205 vertical screen(+6)
            _ = sb
                .Append(";").Append(Machines.Totals.Working)
                .Append(";").Append(Machines.Totals.NotWorking)
                .Append(";").Append(Machines.Totals.Mechanicals)
                .Append(";").Append(Machines.Totals.NotMechanicals)
                .Append(";").Append(Machines.Totals.SaveSupported)
                .Append(";").Append(Machines.Totals.SaveUnsupported)
                .Append(";").Append(Machines.Totals.HorizontalScreen)
                .Append(";").Append(Machines.Totals.VerticalScreen)
                .AppendLine();
            // Riga 3
            // 351.491 total roms(+254), 348.213 machines roms(+245), 2.658 devices roms(+8), 620 BIOSes roms(+1), 1.325 CHDs(+1), 595 sample files, 77 sample packs, 342.506 good dumps(+249), 5.701 no dumps(+5), 4.609 bad dumps(+1), 6 bugs fixed
            _ = sb
                .Append(";").Append(Machines.Totals.TotalRoms)
                .Append(";").Append(Machines.Totals.MachineRoms)
                .Append(";").Append(Machines.Totals.DevicesRoms)
                .Append(";").Append(Machines.Totals.BiosRoms)
                .Append(";").Append(Machines.Totals.TotalDisks)
                .Append(";").Append(Machines.Totals.SampleFiles)
                .Append(";").Append(Machines.Totals.SamplePacks)
                .Append(";").Append(Machines.Totals.GoodDumpsRoms)
                .Append(";").Append(Machines.Totals.NoDumpsRoms)
                .Append(";").Append(Machines.Totals.BadDumpsRoms)
                //.Append(";").Append(Machines.Totals.BugsFixed)
                .AppendLine();
            // Riga 4
            // 714 software list(+1), 137.832 software(+343), 704 active SL(+2), 10 orphan SL(-1), 137.072 active software(+346), 760 orphan software(-3), 95.046 software parents(+274), 42.786 software clones(+69)
            _ = sb
                .Append(";").Append(SoftwareLists.Totals.SoftwareLists)
                .Append(";").Append(SoftwareLists.Totals.SoftwareRoms)
                .Append(";").Append(SoftwareLists.Totals.SoftwareLists)
                .Append(";").Append(OrphansSoftwareLists)
                .Append(";").Append(SoftwareLists.Totals.Parents)
                .Append(";").Append(SoftwareLists.Totals.Clones)
                .AppendLine();
            // Riga 5
            // 233.686 software roms(+407), 11.065 software CHD(+1), 97.578 supported software(+245), 1.738 partially supported software(+5), 38.516 unsupported software(+93)
            _ = sb
                .Append(";").Append(SoftwareLists.Totals.SoftwareRoms)
                .Append(";").Append(SoftwareLists.Totals.SoftwareRoms)
                .Append(";").Append(SoftwareLists.Totals.SupportedSoftware)
                .Append(";").Append(SoftwareLists.Totals.PartiallySupportedSoftware)
                .Append(";").Append(SoftwareLists.Totals.UnsupportedSoftware)
                .AppendLine();

            //    _ = sb
            //        .AppendLine()
            //        .Append($"$0.{ReleaseNumber}")    // $0.265 [#704]
            //        .Append($" [#{releaseId ?? "???"}] ***NEW***")
            //        .AppendLine()
            //        .AppendLine(releaseDate?.ToString("yyyy/MM/dd") ?? Build)   // aaaa/mm/gg
            //    ;

            //    // Riga 1
            //    // 46.750 total items, 3.005 drivers(+8), 40.309 machines(+34), 13.841 parents(+17), 26.544 clones(+17), 76 BIOSes, 6.365 devices(-1 / +22), 1.195 requires CHDs(+1), 1.862 use samples(+22)
            //    _ = sb
            //        .Append(Machines.Totals.Items.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.Drivers.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.Machines.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.Parents.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.Clones.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.Bioses.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.Devices.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.RequiresDisks.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.UseSamples.CountFormattedText())
            //        .AppendLine();
            //    // Riga 2
            //    // 15.378 working(+23), 25.007 not working(+11), 15.618 mechanicals(+1), 24.767 not mechanicals(+33), 13.859 save supported(+14), 26.526 save unsupported(+20), 37.180 horizontal screen(+28), 3.205 vertical screen(+6)
            //    _ = sb
            //        .Append(Machines.Totals.Working.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.NotWorking.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.Mechanicals.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.NotMechanicals.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.SaveSupported.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.SaveUnsupported.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.HorizontalScreen.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.VerticalScreen.CountFormattedText())
            //        .AppendLine();
            //    // Riga 3
            //    // 351.491 total roms(+254), 348.213 machines roms(+245), 2.658 devices roms(+8), 620 BIOSes roms(+1), 1.325 CHDs(+1), 595 sample files, 77 sample packs, 342.506 good dumps(+249), 5.701 no dumps(+5), 4.609 bad dumps(+1), 6 bugs fixed
            //    _ = sb
            //        .Append(Machines.Totals.TotalRoms.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.MachineRoms.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.DevicesRoms.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.BiosRoms.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.TotalDisks.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.SampleFiles.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.SamplePacks.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.GoodDumpsRoms.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.NoDumpsRoms.CountFormattedText())
            //        .Append(", ").Append(Machines.Totals.BadDumpsRoms.CountFormattedText())
            //        //.Append(", ").Append(Machines.Totals.BugsFixed.CountFormattedText())
            //        .AppendLine();
            //}
            //if (SoftwareLists.Any() || SoftwareListHashes.Any())
            //{
            //    // Riga 4
            //    // 714 software list(+1), 137.832 software(+343), 704 active SL(+2), 10 orphan SL(-1), 137.072 active software(+346), 760 orphan software(-3), 95.046 software parents(+274), 42.786 software clones(+69)
            //    _ = sb
            //        .Append(SoftwareListHashes.Totals.SoftwareLists.CountFormattedText())
            //        .Append(", ").Append(SoftwareListHashes.Totals.Software.CountFormattedText())
            //        .Append(", ").Append(SoftwareLists.Totals.SoftwareLists.CountFormattedText())
            //        .Append(", ").Append(OrphansSoftwareLists.CountFormattedText())
            //        .Append(", ").Append(SoftwareLists.Totals.Software.CountFormattedText())
            //        .Append(", ").Append(OrphansSoftware.CountFormattedText())
            //        .Append(", ").Append(SoftwareLists.Totals.Parents.CountFormattedText())
            //        .Append(", ").Append(SoftwareLists.Totals.Clones.CountFormattedText())
            //        .AppendLine();
            //    // Riga 5
            //    // 233.686 software roms(+407), 11.065 software CHD(+1), 97.578 supported software(+245), 1.738 partially supported software(+5), 38.516 unsupported software(+93)
            //    _ = sb
            //        .Append(SoftwareLists.Totals.SoftwareRoms.CountFormattedText())
            //        .Append(", ").Append(SoftwareLists.Totals.SoftwareDisks.CountFormattedText())
            //        .Append(", ").Append(SoftwareLists.Totals.SupportedSoftware.CountFormattedText())
            //        .Append(", ").Append(SoftwareLists.Totals.PartiallySupportedSoftware.CountFormattedText())
            //        .Append(", ").Append(SoftwareLists.Totals.UnsupportedSoftware.CountFormattedText())
            //        .AppendLine();
        }
        return sb.ToString();
    }

    public string GetSoftwareListHashesAsCsv()
    {
        if (!SoftwareListHashes.Any())
            return string.Empty;
        var sb = new StringBuilder();
        var QUOTE = "\"";
        var SEPARATOR = ";";
        _ = sb
            .Append("SOFTWARE_LIST")
            .Append(SEPARATOR)
            .Append("SOFTWARE")
            .Append(SEPARATOR)
            .Append("DESCRIPTION")
            .Append(SEPARATOR)
            .Append("CLONE_OF")
            .Append(SEPARATOR)
            .Append("SUPPORTED")
            .Append(SEPARATOR)
            .Append("YEAR")
            .Append(SEPARATOR)
            .Append("PUBLISHER")
            .AppendLine();
        foreach (var softwareList in SoftwareListHashes)
        {
            foreach (var software in softwareList.Software)
            {
                _ = sb
                    .Append(softwareList.Name)
                    .Append(SEPARATOR)
                    .Append(software.Name)
                    .Append(SEPARATOR)
                    .Append(QUOTE + software.Description?.Replace("\"", "'") + QUOTE)
                    .Append(SEPARATOR)
                    .Append(software.CloneOf)
                    .Append(SEPARATOR)
                    .Append(software.Supported)
                    .Append(SEPARATOR)
                    .Append(software.Year)
                    .Append(SEPARATOR)
                    .Append(QUOTE + software.Publisher?.Replace("\"", "'") + QUOTE)
                    .Append(SEPARATOR)
                    .AppendLine();
            }
        }
        return sb.ToString();
    }

    //public string GetSoftwareListTotals()
    //{
    //    var SEPARATOR = ";";
    //    var allLists = new List<string>();
    //    allLists.AddRange(SoftwareListHashes.Select(x => x.Name).OrderBy(x => x));
    //    allLists.AddRange(SoftwareLists.Select(x => x.Name).OrderBy(x => x));
    //    var sb = new StringBuilder();
    //    sb
    //        .AppendLine("CONTEGGI SOFTWARE LIST")
    //        .AppendLine("----------------------")
    //        .Append("SOFTWARE LIST")
    //        .Append(SEPARATOR)
    //        .Append("HASH")
    //        .Append(SEPARATOR)
    //        .Append("XML")
    //        .Append(SEPARATOR)
    //        .Append("ESITO")
    //        .AppendLine();
    //    foreach (var list in allLists.OrderBy(x => x).Distinct())
    //    {
    //        var countHash = SoftwareListHashes.FirstOrDefault(x => x.Name == list)?.Software?.Count() ?? 0;
    //        var countXml = SoftwareLists.FirstOrDefault(x => x.Name == list)?.Software?.Count() ?? 0;
    //        sb
    //            .Append(list)
    //            .Append(SEPARATOR)
    //            .Append(countHash)
    //            .Append(SEPARATOR)
    //            .Append(countXml)
    //            .Append(SEPARATOR)
    //            .Append(countXml == countHash ? "OK" : "ERROR")
    //            .AppendLine();
    //    }
    //    sb
    //        .AppendLine()
    //        .AppendLine();
    //    return sb.ToString();
    //}

    public async static Task<MameConfiguration> LoadMameConfiguration(string executableFilePath, CancellationToken cancellationToken = default)
    {
        var ret = new Config.MameConfiguration(executableFilePath);
        if (string.IsNullOrEmpty(executableFilePath) || !File.Exists(executableFilePath))
            throw new Exception($"File {executableFilePath} non trovato");
        FileInfo fi = new(executableFilePath);
        using var proc = new Process();
        proc.StartInfo.WorkingDirectory = fi.Directory.FullName;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.FileName = executableFilePath;
        proc.StartInfo.Arguments = "-showconfig";
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.CreateNoWindow = true;
        _ = proc.Start();

        var j = 0;
        var line = string.Empty;
        while ((line = await proc.StandardOutput.ReadLineAsync()) is not null)
        {
            j++;
            if (j % 100 == 0)
                cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(line)) continue;
            line = line.Trim();
            if (line.StartsWith("#") || line.StartsWith(";")) continue;

            if (TryGetValue(line, "rompath", out var romPath))
                ret.RomPath = romPath ?? "roms";
            else if (TryGetValue(line, "hashpath", out var hashPath))
                ret.HashPath = hashPath ?? "hash";
            else if (TryGetValue(line, "homepath", out var homePath))
                ret.HomePath = homePath ?? ".";
            else if (TryGetValue(line, "samplepath", out var samplePath))
                ret.SamplePath = samplePath ?? "samples";
            else if (TryGetValue(line, "artpath", out var artPath))
                ret.ArtworkPath = artPath ?? "artwork";
            else if (TryGetValue(line, "ctrlrpath", out var ctrlrPath))
                ret.ControllerPath = ctrlrPath ?? "ctrlr";
            else if (TryGetValue(line, "inipath", out var iniPath))
                ret.IniPath = iniPath ?? ".;ini;ini/presets";
            else if (TryGetValue(line, "fontpath", out var fontPath))
                ret.FontPath = fontPath ?? ".";
            else if (TryGetValue(line, "cheatpath", out var cheatPath))
                ret.CheatPath = cheatPath ?? "cheat";
            else if (TryGetValue(line, "crosshairpath", out var crosshairPath))
                ret.CrosshairPath = crosshairPath ?? "crosshair";
            else if (TryGetValue(line, "pluginspath", out var pluginsPath))
                ret.PluginsPath = pluginsPath ?? "plugins";
            else if (TryGetValue(line, "languagepath", out var languagePath))
                ret.LanguagePath = languagePath ?? "language";
            else if (TryGetValue(line, "swpath", out var swPath))
                ret.SoftwarePath = swPath ?? "software";
            else if (TryGetValue(line, "cfg_directory", out var cfgDirectory))
                ret.ConfigDirectory = cfgDirectory ?? "cfg";
            else if (TryGetValue(line, "nvram_directory", out var nvramDirectory))
                ret.NvramDirectory = nvramDirectory ?? "nvram";
            else if (TryGetValue(line, "input_directory", out var inputDirectory))
                ret.InputPlaybackDirectory = inputDirectory ?? "inp";
            else if (TryGetValue(line, "state_directory", out var stateDirectory))
                ret.StateDirectory = stateDirectory ?? "sta";
            else if (TryGetValue(line, "snapshot_directory", out var snapPath))
                ret.SnapshotDirectory = snapPath ?? "snap";
            else if (TryGetValue(line, "diff_directory", out var diffDirectory))
                ret.DiffDirectory = diffDirectory ?? "diff";
            else if (TryGetValue(line, "comment_directory", out var commentDirectory))
                ret.CommentDirectory = commentDirectory ?? "comments";
            else if (TryGetValue(line, "share_directory", out var shareDirectory))
                ret.ShareDirectory = shareDirectory ?? "share";
        }
        //var errors = await proc.StandardError.ReadToEndAsync();
        return ret;
    }

    private static bool TryGetValue(string line, string key, out string? value)
    {
        value = null;
        var part = key + " ";
        if (line.StartsWith(part, StringComparison.OrdinalIgnoreCase))
        {
            value = line.Substring(part.Length).Trim();
            return true;
        }
        return false;
    }

}
