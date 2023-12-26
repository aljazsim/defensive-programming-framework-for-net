namespace DefensiveProgrammingFramework;

/// <summary>
/// The then extensions methods.
/// </summary>
public static class ThenExtensions
{
    #region Public Methods

    /// <summary>
    /// Executes the specified action when the condition result is true.
    /// </summary>
    /// <param name="conditionResult">If set to <c>true</c> the specified action will execute.</param>
    /// <param name="onTrue">The action that will execute if the condition result is true..</param>
    public static void Then(this bool conditionResult, Action onTrue)
    {
        onTrue.CannotBeNull();

        if (conditionResult)
        {
            onTrue();
        }
    }

    #endregion Public Methods
}
