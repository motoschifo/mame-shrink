#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace MAME_Shrink.Common.Filters;
internal class FilterMenuCollection : Collection<FilterMenuItem>
{
    public void Initialize()
    {
        Clear();

        Add(new FilterMenuItem { Text = "Tutti", Kind = FilterKind.All });

        Add(new FilterMenuItem { IsSeparator = true });

        Add(new FilterMenuItem
        {
            Text = "Tipo",
            Children =
            {
                new FilterMenuItem { Text = "Mamecab", Kind = FilterKind.IsMamecab },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = "Gioco", Kind = FilterKind.IsMachine },
                new FilterMenuItem { Text = "Gioco parent", Kind = FilterKind.IsParentMachine },
                new FilterMenuItem { Text = "Gioco clone", Kind = FilterKind.IsCloneMachine },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = "Bios", Kind = FilterKind.IsBios },
                new FilterMenuItem { Text = "Dispositivo", Kind = FilterKind.IsDevice },
                new FilterMenuItem { Text = "Meccanico", Kind = FilterKind.IsMechanical },
            }
        });

        Add(new FilterMenuItem
        {
            Text = "Audio",
            Children =
            {
                new FilterMenuItem { Text = "Audio non supportato", Kind = FilterKind.AudioUnsupported },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = "Audio mono", Kind = FilterKind.AudioChannelMono },
                new FilterMenuItem { Text = "Audio stereo", Kind = FilterKind.AudioChannelStereo },
                new FilterMenuItem { Text = "Audio multicanale", Kind = FilterKind.AudioMultichannel },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = "Suono emulato correttamente", Kind = FilterKind.SoundEmulated },
                new FilterMenuItem { Text = "Suono imperfetto", Kind = FilterKind.SoundImperfect },
                new FilterMenuItem { Text = "Suono non emulato", Kind = FilterKind.SoundUnemulated },
            }
        });

        Add(new FilterMenuItem
        {
            Text = "Video",
            Children =
                [
                 new FilterMenuItem
                 {
                    Text = "Tipo schermo",
                    Children =
                    {
                        new FilterMenuItem { Text = "Raster", Kind = FilterKind.DisplayTypeRaster },
                        new FilterMenuItem { Text = "Vettoriale", Kind = FilterKind.DisplayTypeVector },
                        new FilterMenuItem { Text = "LCD", Kind = FilterKind.DisplayTypeLCD },
                        new FilterMenuItem { Text = "SVG", Kind = FilterKind.DisplayTypeSVG },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Sconosciuto", Kind = FilterKind.DisplayTypeUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Numero di schermi",
                    Children =
                    {
                        new FilterMenuItem { Text = "Nessuno", Kind = FilterKind.Screenless },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Uno", Kind = FilterKind.ScreensOne },
                        new FilterMenuItem { Text = "Uno o più", Kind = FilterKind.ScreensOneOrMore },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Due", Kind = FilterKind.ScreensTwo },
                        new FilterMenuItem { Text = "Due o più", Kind = FilterKind.ScreensTwoOrMore },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Tre", Kind = FilterKind.ScreensThree },
                        new FilterMenuItem { Text = "Tre o più", Kind = FilterKind.ScreensThreeOrMore },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Quattro", Kind = FilterKind.ScreensFour },
                        new FilterMenuItem { Text = "Quattro o più", Kind = FilterKind.ScreensFourOrMore },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Più di quattro", Kind = FilterKind.ScreensFiveOrMore },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Orientamento",
                    Children =
                    {
                        new FilterMenuItem { Text = "Orizzontale", Kind = FilterKind.HorizontalScreen },
                        new FilterMenuItem { Text = "Verticale", Kind = FilterKind.VerticalScreen },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Nessuna rotazione", Kind = FilterKind.ScreenRotated0 },
                        new FilterMenuItem { Text = "Rotazione 90°", Kind = FilterKind.ScreenRotated90 },
                        new FilterMenuItem { Text = "Rotazione 180°", Kind = FilterKind.ScreenRotated180 },
                        new FilterMenuItem { Text = "Rotazione 270°", Kind = FilterKind.ScreenRotated270 },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Grafica",
                    Children =
                    {
                        new FilterMenuItem { Text = "Emulata correttamente", Kind = FilterKind.GraphicEmulated },
                        new FilterMenuItem { Text = "Con imperfezioni", Kind = FilterKind.GraphicImperfect },
                        new FilterMenuItem { Text = "Non emulata", Kind = FilterKind.GraphicNotEmulated },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Colore",
                    Children =
                    {
                        new FilterMenuItem { Text = "Emulato correttamente", Kind = FilterKind.ColorEmulated },
                        new FilterMenuItem { Text = "Con imperfezioni", Kind = FilterKind.ColorImperfect },
                        new FilterMenuItem { Text = "Non emulato", Kind = FilterKind.ColorUnemulated },
                    }
                }
            ],
        });

        Add(new FilterMenuItem { IsSeparator = true });

        Add(new FilterMenuItem
        {
            Text = "Driver",
            Children =
            {
                new FilterMenuItem
                {
                    Text = "Stato",
                    Children =
                    {
                        new FilterMenuItem { Text = "Funzionante", Kind = FilterKind.DriverWorking },
                        new FilterMenuItem { Text = "Con imperfezioni", Kind = FilterKind.DriverImperfect },
                        new FilterMenuItem { Text = "Non funzionante", Kind = FilterKind.DriverNotWorking },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Sconosciuto", Kind = FilterKind.DriverUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Emulazione",
                    Children =
                    {
                        new FilterMenuItem { Text = "Buona", Kind = FilterKind.EmulationGood },
                        new FilterMenuItem { Text = "Con imperfezioni", Kind = FilterKind.EmulationImperfect },
                        new FilterMenuItem { Text = "Non funzionante", Kind = FilterKind.EmulationPreliminary },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Sconosciuta", Kind = FilterKind.EmulationUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Cocktail",
                    Children =
                    {
                        new FilterMenuItem { Text = "Buono", Kind = FilterKind.CocktailGood },
                        new FilterMenuItem { Text = "Con imperfezioni", Kind = FilterKind.CocktailImperfect },
                        new FilterMenuItem { Text = "Preliminare", Kind = FilterKind.CocktailPreliminary},
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Sconosciuto", Kind = FilterKind.CocktailUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Salvataggio",
                    Children =
                    {
                        new FilterMenuItem { Text = "Supportato", Kind = FilterKind.SaveStateSupported },
                        new FilterMenuItem { Text = "Non supportato", Kind = FilterKind.SaveStateUnsupported },
                        new FilterMenuItem { IsSeparator = true },
                        new FilterMenuItem { Text = "Sconosciuto", Kind = FilterKind.SaveStateUnknown },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Artwork",
                    Children =
                    {
                        new FilterMenuItem { Text = "Richiesto", Kind = FilterKind.ArtworkRequired },
                        new FilterMenuItem { Text = "Non richiesto", Kind = FilterKind.ArtworkNotRequired },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Licenza",
                    Children =
                    {
                        new FilterMenuItem { Text = "Ufficiale", Kind = FilterKind.DriverOfficial },
                        new FilterMenuItem { Text = "Non ufficiale", Kind = FilterKind.DriverUnofficial },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Hardware",
                    Children =
                    {
                        new FilterMenuItem { Text = "Dispositivi sonori presenti", Kind = FilterKind.SoundHardwareYes },
                        new FilterMenuItem { Text = "Dispositivi sonori non presenti", Kind = FilterKind.SoundHardwareNo },
                    }
                },
                new FilterMenuItem
                {
                    Text = "Stato lavori",
                    Children =
                    {
                        new FilterMenuItem { Text = "Completa", Kind = FilterKind.DriverComplete },
                        new FilterMenuItem { Text = "Parziale", Kind = FilterKind.DriverIncomplete },
                    }
                },
            }
        });

        Add(new FilterMenuItem
        {
            Text = "Classificazioni",
            Children =
            {
                new FilterMenuItem { Text = "Senza genere", Kind = FilterKind.NoGenre },
                new FilterMenuItem { Text = "Genere", Kind = FilterKind.Genre, Enabled = false },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = "Senza categoria", Kind = FilterKind.NoCategory },
                new FilterMenuItem { Text = "Categoria", Kind = FilterKind.Category, Enabled = false },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = "Non appartenente ad una serie specifica", Kind = FilterKind.NoSerie, Enabled = false },
                new FilterMenuItem { Text = "Serie", Kind = FilterKind.Serie, Enabled = false },
            }
        });

        Add(new FilterMenuItem
        {
            Text = "Sample",
            Children =
            {
                new FilterMenuItem { Text = "Usa sample", Kind = FilterKind.UseSample },
                new FilterMenuItem { Text = "Non usa sample", Kind = FilterKind.DoNotUseSample },
            }
        });

        Add(new FilterMenuItem
        {
            Text = "Dischi",
            Children =
            {
                new FilterMenuItem { Text = "Richiede CHD", Kind = FilterKind.RequiresDisk },
                new FilterMenuItem { Text = "Non richiede CHD", Kind = FilterKind.DoNotRequiresDisk },
                new FilterMenuItem { IsSeparator = true },
                new FilterMenuItem { Text = "Usa CHD good", Kind = FilterKind.DiskStatusGood },
                new FilterMenuItem { Text = "Usa CHD bad dump", Kind = FilterKind.DiskStatusBadDump },
                new FilterMenuItem { Text = "Usa CHD no dump", Kind = FilterKind.DiskStatusNoDump },
            }
        });

        Add(new FilterMenuItem
        {
            Text = "Versione Mame",
            Children =
            {
                new FilterMenuItem { Text = "Per numero di versione", Kind = FilterKind.Release, Enabled = false },
            }
        });

        Add(new FilterMenuItem { IsSeparator = true });

        Add(new FilterMenuItem
        {
            Text = "Protezione",
            Children =
            {
                new FilterMenuItem { Text = "Emulata correttamente", Kind = FilterKind.ProtectionEmulated},
                new FilterMenuItem { Text = "Con imperfezioni", Kind = FilterKind.ProtectionImperfect},
                new FilterMenuItem { Text = "Non emulata", Kind = FilterKind.ProtectionUnemulated },
            }
        });
    }

    public void BuildMenuItems(ToolStripItemCollection menuItems, EventHandler clickHandler)
    {
        menuItems.Clear();
        BuildMenuItems(this, menuItems, clickHandler);
    }

    private void BuildMenuItems(IEnumerable<FilterMenuItem> items, ToolStripItemCollection target, EventHandler clickHandler)
    {
        foreach (var item in items)
        {
            if (item.IsSeparator)
            {
                target.Add(new ToolStripSeparator());
                continue;
            }

            var menuItem = new ToolStripMenuItem(item.Text)
            {
                Tag = item.Kind,
                Enabled = item.Enabled
            };

            if (item.Children.Any())
            {
                BuildMenuItems(item.Children, menuItem.DropDownItems, clickHandler);
            }
            else
            {
                menuItem.Click += clickHandler;
            }

            target.Add(menuItem);
        }
    }
}