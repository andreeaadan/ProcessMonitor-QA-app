using System;

namespace monitor
{
    public class ArgumentParser
    {
        public string ProcessName { get; }
        public int MaxLifetime { get; }
        public int MonitoringFrequency { get; }

        public static readonly string InvalidNumberOfArgumentsErrorMessage = "Command must have three arguments: processName maxLifetime monitoringFrequency";
        public static readonly string InvalidMaxLifetimeErrorMessage = "Invalid maxLifetime. Please provide a positive integer value greater than 0 and less than or equal to 1440 minutes for maxLifetime.";
        public static readonly string InvalidMonitoringFrequencyErrorMessage = "Invalid monitoringFrequency. Please provide a positive integer value greater than 0 and less than or equal to 60 minutes for monitoringFrequency.";
        public static readonly string InvalidConfigurationErrorMessage = "Invalid configuration. Monitoring frequency must be less than or equal to the maximum lifetime.";

        public ArgumentParser(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException(InvalidNumberOfArgumentsErrorMessage);
            }

            // Parse processName
            ProcessName = args[0].Trim();

            // Parse maxLifetime
            if (!int.TryParse(args[1].Trim(), out int maxLifetime) || maxLifetime <= 0 || maxLifetime > 1440)
            {
                throw new ArgumentException(InvalidMaxLifetimeErrorMessage);
            }
            MaxLifetime = maxLifetime;

            // Parse monitoringFrequency
            if (!int.TryParse(args[2].Trim(), out int monitoringFrequency) || monitoringFrequency <= 0 || monitoringFrequency > 60)
            {
                throw new ArgumentException(InvalidMonitoringFrequencyErrorMessage);
            }
            MonitoringFrequency = monitoringFrequency;

            // Check for invalid configuration
            if (MonitoringFrequency > MaxLifetime)
            {
                throw new ArgumentException(InvalidConfigurationErrorMessage);
            }
        }
    }
}
