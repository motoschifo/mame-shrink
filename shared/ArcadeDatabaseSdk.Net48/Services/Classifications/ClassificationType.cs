#nullable enable
namespace ArcadeDatabaseSdk.Net48.Services.Categories;

public partial class ClassificationsApiResult
{
    public enum ClassificationType
    {
        /// <summary>catlist.ini</summary>
        Category,

        /// <summary>genre.ini</summary>
        Genre,

        /// <summary>series.ini</summary>
        Serie,

        /// <summary>languages.ini</summary>
        Language,

        /// <summary>softwarelist from machines</summary>
        SoftwareList,

        /// <summary>sourcefile from machines</summary>
        SourceFile,

        /// <summary>manufacturer from machines</summary>
        MachineManufacturer,

        /// <summary>publisher from software</summary>
        SoftwarePublisher,

        /// <summary>cpu chips from machines</summary>
        ChipCpu,

        /// <summary>audio chips from machines</summary>
        ChipAudio,

        /// <summary>screen width from machines</summary>
        ScreenWidth,

        /// <summary>screen height from machines</summary>
        ScreenHeight,

        /// <summary>game year from machines</summary>
        MachineYear,

        /// <summary>software year from software</summary>
        SoftwareYear,

        /// <summary>screen refresh from machines</summary>
        ScreenRefresh,

        /// <summary>feature compatibility from software</summary>
        SoftwareCompatibility,

        /// <summary>monochrome.ini</summary>
        ScreenMonochrome,

        /// <summary>rankings.ini</summary>
        Ranking,

        /// <summary>bestgames.ini</summary>
        BestGame,

        /// <summary>alltime.ini</summary>
        AllTime,

        /// <summary>cabinets.ini</summary>
        Cabinet,
    }

    //public static ClassificationType ParseClassification(string? value) => value.ToEnum(ClassificationType.Genre, ClassificationType.Genre);
}