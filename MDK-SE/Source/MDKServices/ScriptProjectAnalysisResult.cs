using System.Collections.Immutable;
using System.Xml.Linq;

namespace Malware.MDKServices
{
    /// <summary>
    /// Represents the results for a single project of an analysis made by <see cref="ScriptUpgrades.Analyze(EnvDTE.Project,ScriptUpgradeAnalysisOptions)"/>.
    /// </summary>
    public class ScriptProjectAnalysisResult
    {
        /// <summary>
        /// Represents the results of an analysis which was ignored and should be disregarded.
        /// </summary>
        public static readonly ScriptProjectAnalysisResult NonScriptProjectResult = new ScriptProjectAnalysisResult(null, null, null, default(WhitelistReference), ImmutableArray<BadReference>.Empty, true);

        /// <summary>
        /// Creates a new instance of <see cref="ScriptProjectAnalysisResult"/>
        /// </summary>
        /// <param name="project"></param>
        /// <param name="projectInfo">Basic information about the analyzed project</param>
        /// <param name="projectDocument">The source XML document of the project file</param>
        /// <param name="whitelist">Whitelist verification results</param>
        /// <param name="badReferences">A list of bad file- or assembly references</param>
        public ScriptProjectAnalysisResult(EnvDTE.Project project, ProjectScriptInfo projectInfo, XDocument projectDocument, WhitelistReference whitelist, ImmutableArray<BadReference> badReferences, bool hasValidGamePath)
        {
            Project = project;
            ProjectInfo = projectInfo;
            ProjectDocument = projectDocument;
            BadReferences = badReferences;
            Whitelist = whitelist;
            IsScriptProject = projectInfo != null;
            HasValidGamePath = hasValidGamePath;
            IsValid = BadReferences.Length == 0 && whitelist.IsValid && hasValidGamePath;
        }

        /// <summary>
        /// This is not a script project and should be ignored.
        /// </summary>
        public bool IsScriptProject { get; }

        /// <summary>
        /// The DTE project
        /// </summary>
        public EnvDTE.Project Project { get; }

        /// <summary>
        /// Basic information about the analyzed project.
        /// </summary>
        public ProjectScriptInfo ProjectInfo { get; }

        /// <summary>
        /// The source XML document of the project file.
        /// </summary>
        public XDocument ProjectDocument { get; }

        /// <summary>
        /// Returns a list of bad file- or assembly references.
        /// </summary>
        public ImmutableArray<BadReference> BadReferences { get; }

        /// <summary>
        /// Determines whether the registered game path is valid.
        /// </summary>
        public bool HasValidGamePath { get; }

        /// <summary>
        /// Whitelist verification result
        /// </summary>
        public WhitelistReference Whitelist { get; }

        /// <summary>
        /// Determines whether the analyzed project is fully valid and do not require any updates.
        /// </summary>
        public bool IsValid { get; }
    }
}
