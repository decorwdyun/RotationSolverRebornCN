using RotationSolver.Data;

namespace RotationSolver
{
    public static class CommandTypeExtensions
    {
        public static string ToStateString(this StateCommandType stateType, JobRole role)
        {
            string stateText = stateType switch
            {
                StateCommandType.Off => "关闭",
                StateCommandType.Auto => "自动",
                StateCommandType.TargetOnly => "仅选目标",
                StateCommandType.Manual => "手动",
                StateCommandType.AutoDuty => "AutoDuty",
                _ => stateType.ToString()
            };

            return stateType == StateCommandType.Auto || stateType == StateCommandType.TargetOnly
                ? $"{stateText} ({DataCenter.TargetingType.GetDescription()})"
                : stateText;
        }

        public static string ToSpecialString(this SpecialCommandType specialType, JobRole role)
        {
            return specialType switch
            {
                SpecialCommandType.EndSpecial => "结束特殊状态",
                SpecialCommandType.HealArea => "范围治疗",
                SpecialCommandType.HealSingle => "单体治疗",
                SpecialCommandType.DefenseArea => "AOE减伤",
                SpecialCommandType.DefenseSingle => "单体减伤",
                SpecialCommandType.DispelStancePositional => "驱散/姿态/真北",
                SpecialCommandType.RaiseShirk => "复活/退避",
                SpecialCommandType.MoveForward => "向前移动",
                SpecialCommandType.MoveBack => "向后移动",
                SpecialCommandType.AntiKnockback => "防击退",
                SpecialCommandType.Burst => "爆发",
                SpecialCommandType.Speed => "加速",
                SpecialCommandType.LimitBreak => "极限技",
                SpecialCommandType.NoCasting => "禁止吟唱",
                SpecialCommandType.Intercepting => "拦截中",
                _ => specialType.ToString()
            };
        }
    }
}