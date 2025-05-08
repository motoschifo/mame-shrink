#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MameTools.Net48.Software;
using static MameTools.Net48.Software.MameSoftware;

namespace MameTools.Net48.SoftwareList;

public class MameSoftwareListCollection : ICollection<MameSoftwareList>
{
    private readonly List<MameSoftwareList> _softwareList = [];
    public Totals Totals { get; private set; } = new();

    public int Count => _softwareList.Count;

    public bool IsReadOnly => false;

    public void Add(MameSoftwareList item)
    {
        _softwareList.Add(item);
        Totals.SoftwareLists.IncrementCount(item.Name);
    }
    public void Clear()
    {
        _softwareList.Clear();
        Totals = new();
    }
    public bool Contains(MameSoftwareList item) => _softwareList.Contains(item);
    public void CopyTo(MameSoftwareList[] array, int arrayIndex) => _softwareList.CopyTo(array, arrayIndex);
    public IEnumerator<MameSoftwareList> GetEnumerator() => _softwareList.GetEnumerator();
    public bool Remove(MameSoftwareList item)
    {
        //if (!_softwareList.Remove(item)) return false;
        //Totals.SoftwareLists--;

        // ATTENZIONE
        // Per poter rimuovere un elemento occorrerebbe fare tutti i calcoli a ritroso
        // e ripristinare così i totali.
        // Per il momento evito e restituisco un errore in fase di rimozione
        throw new NotImplementedException();
    }
    IEnumerator IEnumerable.GetEnumerator() => _softwareList.GetEnumerator();

    public void AddSoftware(MameSoftwareList list, MameSoftware software)
    {
        list.Software.Add(software);

        var name = $"{list.Name};{software.Name}";
        // Calcolo totali SL attive/orfane
        Totals.Software.IncrementCount(name);
        if (software.IsParent)
        {
            Totals.Parents.IncrementCount(name);
            list.ContainsParentSoftware = true;
        }
        if (software.IsClone)
        {
            Totals.Clones.IncrementCount(name);
            list.ContainsCloneSoftware = true;
        }
        Totals.SoftwareRoms.IncrementCount([.. software.AllRoms.Select(x => $"{name};{x.Name}")]);
        Totals.SoftwareDisks.IncrementCount([.. software.AllDisks.Select(x => $"{name};{x.Name}")]);
        if (software.Supported == SupportedKind.no)
        {
            Totals.UnsupportedSoftware.IncrementCount(name);
            list.ContainsUnsupportedSoftware = true;
        }
        else if (software.Supported == SupportedKind.partial)
        {
            Totals.PartiallySupportedSoftware.IncrementCount(name);
            list.ContainsPartiallySupportedSoftware = true;
        }
        else
        {
            Totals.SupportedSoftware.IncrementCount(name);
            list.ContainsSupportedSoftware = true;
        }
    }

}
