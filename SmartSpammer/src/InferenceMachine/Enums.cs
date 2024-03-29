namespace FuzzySelector.SmartSpammer.InferenceMachine {

    /// <summary>
    ///   Tipurile de algoritmi pentru realizarea inferenței. 
    /// </summary>
    public enum InferenceAlgorithms : int { fuzzyRulesInference = 1, multicriteriaDecisionMaking = 2 };

    /// <summary>
    ///   Funcția de transformare a importanței.
    /// </summary>
    public enum ImportanceParsingFunction : int { highPolinomial = 0, exponential = 1, logarithmic = 2 };

    /// <summary>
    ///   Algoritmul de activare a regulilor.
    /// </summary>
    public enum RuleActivationAlgorithms : int { minimumPropertyActivationLevel = 1, mediumPropertyActivationLevel = 2 };

    /// <summary>
    ///   Algoritmul de determinare a nivelului de activare al deciziei finale.
    /// </summary>
    public enum DecisionActivationAlgorithms : int { maximumDecisionActivationLevel = 1, mediumDecisionActivationLevel = 2 };
}