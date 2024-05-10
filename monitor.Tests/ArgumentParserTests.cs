using NUnit.Framework;
using System;

namespace monitor.Tests
{
    [TestFixture]
    public class ArgumentParserTests
    {
        private ArgumentParser argumentParser;

        [Test]
        public void ValidArguments_ParsesArgumentsCorrectly()
        {
            // Arrange
            string[] validArgs = { "notepad", "5", "1" };
            argumentParser = new ArgumentParser(validArgs);

            // Act & Assert
            Assert.That(argumentParser.ProcessName, Is.EqualTo("notepad"), "Process name should be parsed correctly.");
            Assert.That(argumentParser.MaxLifetime, Is.EqualTo(5), "Max lifetime should be parsed correctly.");
            Assert.That(argumentParser.MonitoringFrequency, Is.EqualTo(1), "Monitoring frequency should be parsed correctly.");
        }

        [Test]
        public void BlankSpacesInArguments_ParsesArgumentsCorrectly()
        {
            // Arrange
            string[] args = { "    notepad  ", "  5  ", "  1  " };

            // Act
            argumentParser = new ArgumentParser(args);

            // Assert
            Assert.That(argumentParser.ProcessName, Is.EqualTo("notepad"), "Process name with blank spaces should be parsed correctly.");
            Assert.That(argumentParser.MaxLifetime, Is.EqualTo(5), "Max lifetime with blank spaces should be parsed correctly.");
            Assert.That(argumentParser.MonitoringFrequency, Is.EqualTo(1), "Monitoring frequency with blank spaces should be parsed correctly.");
        }

        [Test]
        public void TooManyArguments_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "5", "1", "extra" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidNumberOfArgumentsErrorMessage),
                "Too many arguments should throw an ArgumentException with the correct message.");
        }

        [Test]
        [TestCase("")]
        [TestCase("notepad")]
        [TestCase("notepad", "5")] 
        public void TooFewArguments_ThrowsArgumentException(params string[] args)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidNumberOfArgumentsErrorMessage),
                "Too few arguments should throw an ArgumentException with the correct message.");
        }

        [Test]
        public void NoArguments_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidNumberOfArgumentsErrorMessage),
                "No arguments should throw an ArgumentException with the correct message.");
        }


        [Test]
        public void NonIntegerMaxLifetime_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "invalid", "1" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidMaxLifetimeErrorMessage),
                "Non-integer maxLifetime should throw an ArgumentException with the correct message.");
        }

        [Test]
        public void NonIntegerMonitoringFrequency_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "5", "invalid" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidMonitoringFrequencyErrorMessage),
                "Non-integer monitoringFrequency should throw an ArgumentException with the correct message.");
        }

        [Test]
        public void ZeroMaxLifetime_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "0", "1" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidMaxLifetimeErrorMessage),
                "Zero maxLifetime should throw an ArgumentException with the correct message.");
        }

        [Test]
        public void ZeroMonitoringFrequency_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "5", "0" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidMonitoringFrequencyErrorMessage),
                "Zero monitoringFrequency should throw an ArgumentException with the correct message.");
        }

        [Test]
        public void NegativeMaxLifetime_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "-5", "1" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidMaxLifetimeErrorMessage),
                "Negative maxLifetime should throw an ArgumentException with the correct message.");
        }

        [Test]
        public void NegativeMonitoringFrequency_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "5", "-1" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidMonitoringFrequencyErrorMessage),
                "Negative monitoringFrequency should throw an ArgumentException with the correct message.");
        }

        [Test]
        public void MinimumValueForMaxLifetime_ParsesArgumentsCorrectly()
        {
            // Arrange
            string[] args = { "notepad", "1", "1" };

            // Act
            argumentParser = new ArgumentParser(args);

            // Assert
            Assert.That(argumentParser.ProcessName, Is.EqualTo("notepad"), "Process name should be parsed correctly.");
            Assert.That(argumentParser.MaxLifetime, Is.EqualTo(1), "Minimum maxLifetime should be parsed correctly.");
            Assert.That(argumentParser.MonitoringFrequency, Is.EqualTo(1), "Monitoring frequency should be parsed correctly.");
            Assert.DoesNotThrow(() => new ArgumentParser(args), "Minimum value for maxLifetime should not throw an exception.");
        }

        [Test]
        public void MinimumValueForMonitoringFrequency_ParsesArgumentsCorrectly()
        {
            // Arrange
            string[] args = { "notepad", "10", "1" };

            // Act
            argumentParser = new ArgumentParser(args);

            // Assert
            Assert.That(argumentParser.ProcessName, Is.EqualTo("notepad"), "Process name should be parsed correctly.");
            Assert.That(argumentParser.MaxLifetime, Is.EqualTo(10), "MaxLifetime should be parsed correctly.");
            Assert.That(argumentParser.MonitoringFrequency, Is.EqualTo(1), "Minimum value for monitoringFrequency should be parsed correctly.");
            Assert.DoesNotThrow(() => new ArgumentParser(args), "Minimum value for monitoringFrequency should not throw an exception.");
        }


        [Test]
        public void MaximumValueForMaxLifetime_ParsesArgumentsCorrectly()
        {
            // Arrange
            string[] args = { "notepad", "1440", "1" };

            // Act
            argumentParser = new ArgumentParser(args);

            // Assert
            Assert.That(argumentParser.ProcessName, Is.EqualTo("notepad"), "Process name should be parsed correctly.");
            Assert.That(argumentParser.MaxLifetime, Is.EqualTo(1440), "Maximum value for maxLifetime should be parsed correctly.");
            Assert.That(argumentParser.MonitoringFrequency, Is.EqualTo(1), "Monitoring frequency should be parsed correctly.");
            Assert.DoesNotThrow(() => new ArgumentParser(args), "Maximum value for maxLifetime should not throw an exception.");
        }

        [Test]
        public void MaximumValueForMonitoringFrequency_ParsesArgumentsCorrectly()
        {
            // Arrange
            string[] args = { "notepad", "61", "60" };

            // Act
            argumentParser = new ArgumentParser(args);

            // Assert
            Assert.That(argumentParser.ProcessName, Is.EqualTo("notepad"), "Process name should be parsed correctly.");
            Assert.That(argumentParser.MaxLifetime, Is.EqualTo(61), "MaxLifetime should be parsed correctly.");
            Assert.That(argumentParser.MonitoringFrequency, Is.EqualTo(60), "Maximum value for monitoringFrequency should be parsed correctly.");
            Assert.DoesNotThrow(() => new ArgumentParser(args), "Maximum value for monitoringFrequency should not throw an exception.");
        }

        [Test]
        public void MaxLifetimeExceedsUpperLimit_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "1441", "1" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidMaxLifetimeErrorMessage),
                "Max lifetime exceeding upper limit should throw an ArgumentException with the correct message.");
        }

        [Test]
        public void MonitoringFrequencyExceedsUpperLimit_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "5", "61" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidMonitoringFrequencyErrorMessage),
                "Monitoring frequency exceeding upper limit should throw an ArgumentException with the correct message.");
        }


        [Test]
        public void MonitoringFrequencyGreaterThanMaxLifetime_ThrowsArgumentException()
        {
            // Arrange
            string[] args = { "notepad", "5", "10" };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ArgumentParser(args));
            Assert.That(exception.Message, Is.EqualTo(ArgumentParser.InvalidConfigurationErrorMessage),
                "Monitoring frequency greater than max lifetime should throw an ArgumentException with the correct message.");
        }

    }
}
