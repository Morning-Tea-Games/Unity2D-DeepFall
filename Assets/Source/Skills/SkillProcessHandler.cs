namespace Skills
{
    public class SkillProcessHandler
    {
        public static SkillProcessHandler Instance => _instance;
        private static SkillProcessHandler _instance = new SkillProcessHandler();

        public float PlayerMovementSpeedModifier = 1f;
    }
}
