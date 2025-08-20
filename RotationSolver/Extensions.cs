using RotationSolver.Data;

namespace RotationSolver
{
    public static class CommandTypeExtensions
    {
        public static string ToStateString(this StateCommandType stateType, JobRole role)
        {
            return stateType == StateCommandType.Auto ? $"{stateType.ToFriendlyString()} (目标：{DataCenter.TargetingType.GetDescription()})" : stateType.ToFriendlyString();
        }

        public static string ToSpecialString(this SpecialCommandType specialType, JobRole role)
        {
            return specialType.ToString();
        }
    }
}