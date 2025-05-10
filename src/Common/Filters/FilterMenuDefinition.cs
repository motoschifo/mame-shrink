#nullable enable
using MAME_Shrink.Resources;

namespace MAME_Shrink.Common.Filters;
internal static class FilterMenuDefinition
{
    public static void Initialize(FilterMenuCollection collection)
    {
        collection.Clear();

        collection.Add(new FilterMenuItem { Text = Strings.FilterAll, Kind = FilterKind.All });

        collection.Add(new FilterMenuItem { IsSeparator = true });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.Type,
            Children =
            {
                new FilterMenuItem { Text = Strings.FilterMameCab, Kind = FilterKind.IsMamecab },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = Strings.FilterMachine, Kind = FilterKind.IsMachine },
                new FilterMenuItem { Text = Strings.FilterParentMachine, Kind = FilterKind.IsParentMachine },
                new FilterMenuItem { Text = Strings.FilterCloneMachine, Kind = FilterKind.IsCloneMachine },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = Strings.FilterBios, Kind = FilterKind.IsBios },
                new FilterMenuItem { Text = Strings.FilterDevice, Kind = FilterKind.IsDevice },
                new FilterMenuItem { Text = Strings.FilterMechanical, Kind = FilterKind.IsMechanical },
            }
        });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.FilterAudio,
            Children =
            {
                new FilterMenuItem { Text = Strings.FilterAudioNotSupported, Kind = FilterKind.AudioUnsupported },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = Strings.FilterAudioMono, Kind = FilterKind.AudioChannelMono },
                new FilterMenuItem { Text = Strings.FilterAudioStereo, Kind = FilterKind.AudioChannelStereo },
                new FilterMenuItem { Text = Strings.FilterAudioMultichannel, Kind = FilterKind.AudioMultichannel },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = Strings.FilterSoundEmulated, Kind = FilterKind.SoundEmulated },
                new FilterMenuItem { Text = Strings.FilterSoundImperfect, Kind = FilterKind.SoundImperfect },
                new FilterMenuItem { Text = Strings.FilterSoundUnemulated, Kind = FilterKind.SoundUnemulated },
            }
        });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.FilterVideo,
            Children =
                [
                 new FilterMenuItem
                 {
                    Text = Strings.FilterDisplayType,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterDisplayRaster, Kind = FilterKind.DisplayTypeRaster },
                        new FilterMenuItem { Text = Strings.FilterDisplayVector, Kind = FilterKind.DisplayTypeVector },
                        new FilterMenuItem { Text = Strings.FilterDisplayLCD, Kind = FilterKind.DisplayTypeLCD },
                        new FilterMenuItem { Text = Strings.FilterDisplaySVG, Kind = FilterKind.DisplayTypeSVG },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterDisplayUnknown, Kind = FilterKind.DisplayTypeUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterScreensNumber,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterScreenless, Kind = FilterKind.Screenless },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterScreenOne, Kind = FilterKind.ScreensOne },
                        new FilterMenuItem { Text = Strings.FilterScreenOneOrMore, Kind = FilterKind.ScreensOneOrMore },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterScreenTwo, Kind = FilterKind.ScreensTwo },
                        new FilterMenuItem { Text = Strings.FilterScreenTwoOrMore, Kind = FilterKind.ScreensTwoOrMore },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterScreenThree, Kind = FilterKind.ScreensThree },
                        new FilterMenuItem { Text = Strings.FilterScreenThreeOrMore, Kind = FilterKind.ScreensThreeOrMore },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterScreenFour, Kind = FilterKind.ScreensFour },
                        new FilterMenuItem { Text = Strings.FilterScreenFourOrMore, Kind = FilterKind.ScreensFourOrMore },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterScreenMoreThanFour, Kind = FilterKind.ScreensFiveOrMore },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterScreenOrientation,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterScreenHorizontal, Kind = FilterKind.HorizontalScreen },
                        new FilterMenuItem { Text = Strings.FilterScreenVertical, Kind = FilterKind.VerticalScreen },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterScreenNoRotation, Kind = FilterKind.ScreenRotated0 },
                        new FilterMenuItem { Text = Strings.FilterScreenRotated90, Kind = FilterKind.ScreenRotated90 },
                        new FilterMenuItem { Text = Strings.FilterScreenRotated180, Kind = FilterKind.ScreenRotated180 },
                        new FilterMenuItem { Text = Strings.FilterScreenRotated270, Kind = FilterKind.ScreenRotated270 },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterGraphic,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterGraphicEmulated, Kind = FilterKind.GraphicEmulated },
                        new FilterMenuItem { Text = Strings.FilterGraphicImperfect, Kind = FilterKind.GraphicImperfect },
                        new FilterMenuItem { Text = Strings.FilterGraphicUnemulated, Kind = FilterKind.GraphicNotEmulated },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterColor,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterColorEmulated, Kind = FilterKind.ColorEmulated },
                        new FilterMenuItem { Text = Strings.FilterColorImperfect, Kind = FilterKind.ColorImperfect },
                        new FilterMenuItem { Text = Strings.FilterColorUnemulated, Kind = FilterKind.ColorUnemulated },
                    }
                }
            ],
        });

        collection.Add(new FilterMenuItem { IsSeparator = true });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.FilterDriver,
            Children =
            {
                new FilterMenuItem
                {
                    Text = Strings.FilterDriverStatus,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterDriverStatusWorking, Kind = FilterKind.DriverWorking },
                        new FilterMenuItem { Text = Strings.FilterDriverStatusImperfect, Kind = FilterKind.DriverImperfect },
                        new FilterMenuItem { Text = Strings.FilterDriverStatusNotWorking, Kind = FilterKind.DriverNotWorking },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterDriverStatusUnknown, Kind = FilterKind.DriverUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterDriverStatus,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterEmulationGood, Kind = FilterKind.EmulationGood },
                        new FilterMenuItem { Text = Strings.FilterEmulationImperfect, Kind = FilterKind.EmulationImperfect },
                        new FilterMenuItem { Text = Strings.FilterEmulationPreliminary, Kind = FilterKind.EmulationPreliminary },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterEmulationUnknown, Kind = FilterKind.EmulationUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterDriverCocktail,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterDriverCocktailGood, Kind = FilterKind.CocktailGood },
                        new FilterMenuItem { Text = Strings.FilterDriverCocktailImperfect, Kind = FilterKind.CocktailImperfect },
                        new FilterMenuItem { Text = Strings.FilterDriverCocktailPreliminary, Kind = FilterKind.CocktailPreliminary},
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterDriverCocktailUnknown, Kind = FilterKind.CocktailUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterSaveState,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterSaveStateSupported, Kind = FilterKind.SaveStateSupported },
                        new FilterMenuItem { Text = Strings.FilterSaveStateUnupported, Kind = FilterKind.SaveStateUnsupported },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = Strings.FilterSaveStateUnknown, Kind = FilterKind.SaveStateUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterArtwork,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterArtworkRequired, Kind = FilterKind.ArtworkRequired },
                        new FilterMenuItem { Text = Strings.FilterArtworkNotRequired, Kind = FilterKind.ArtworkNotRequired },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterLicense,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterLicenseOfficial, Kind = FilterKind.DriverOfficial },
                        new FilterMenuItem { Text = Strings.FilterLicenseUnofficial, Kind = FilterKind.DriverUnofficial },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterHardware,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterSoundHardwareYes, Kind = FilterKind.SoundHardwareYes },
                        new FilterMenuItem { Text = Strings.FilterSoundHardwareNo, Kind = FilterKind.SoundHardwareNo },
                    }
                },
                new FilterMenuItem
                {
                    Text = Strings.FilterCompletion,
                    Children =
                    {
                        new FilterMenuItem { Text = Strings.FilterComplete, Kind = FilterKind.DriverComplete },
                        new FilterMenuItem { Text = Strings.FilterInomplete, Kind = FilterKind.DriverIncomplete },
                    }
                },
            }
        });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.FilterCategories,
            Children =
            {
                new FilterMenuItem { Text = Strings.FilterNoGenre, Kind = FilterKind.NoGenre },
                new FilterMenuItem { Text = Strings.FilterByGenre, Kind = FilterKind.Genre, UpdateCounter = false, Enabled = false},
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = Strings.FilterNoCategories, Kind = FilterKind.NoCategory },
                new FilterMenuItem { Text = Strings.FilterByCategory, Kind = FilterKind.Category, UpdateCounter = false, Enabled = false },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = Strings.FilterNoSeries, Kind = FilterKind.NoSerie, Enabled = false },
                new FilterMenuItem { Text = Strings.FilterBySerie, Kind = FilterKind.Serie, UpdateCounter = false, Enabled = false },
            }
        });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.FilterSample,
            Children =
            {
                new FilterMenuItem { Text = Strings.FilterUseSample, Kind = FilterKind.UseSample },
                new FilterMenuItem { Text = Strings.FilterDoNotUseSample, Kind = FilterKind.DoNotUseSample },
            }
        });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.FilterDisks,
            Children =
            {
                new FilterMenuItem { Text = Strings.FilterRequiresCHD, Kind = FilterKind.RequiresDisk },
                new FilterMenuItem { Text = Strings.FilterDoNotRequiresCHD, Kind = FilterKind.DoNotRequiresDisk },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = Strings.FilterDiskStatusGood, Kind = FilterKind.DiskStatusGood },
                new FilterMenuItem { Text = Strings.FilterDiskStatusBadDump, Kind = FilterKind.DiskStatusBadDump },
                new FilterMenuItem { Text = Strings.FilterDiskStatusNoDump, Kind = FilterKind.DiskStatusNoDump },
            }
        });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.Release,
            Children =
            {
                new FilterMenuItem { Text = Strings.FilterByReleaseNumber, Kind = FilterKind.Release, Enabled = false },
            }
        });

        collection.Add(new FilterMenuItem { IsSeparator = true });

        collection.Add(new FilterMenuItem
        {
            Text = Strings.FilterProtection,
            Children =
            {
                new FilterMenuItem { Text = Strings.FilterProtectionEmulated, Kind = FilterKind.ProtectionEmulated},
                new FilterMenuItem { Text = Strings.FilterProtectionImperfect, Kind = FilterKind.ProtectionImperfect},
                new FilterMenuItem { Text = Strings.FilterProtectionUnemulated, Kind = FilterKind.ProtectionUnemulated },
            }
        });
    }
}
