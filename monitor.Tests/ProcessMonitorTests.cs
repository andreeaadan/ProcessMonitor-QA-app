/*

1.	Test Name: ProcessMonitor_KillsProcess_WhenMaxLifetimeExceeded
    •	Purpose: Verifies that the process monitoring utility correctly terminates a process when its lifetime exceeds the specified maximum.
    •	Arrange: Sets up a test process with a specific name and a short maximum lifetime.
    •	Act: Allows the process to run for a duration longer than the maximum allowed.
    •	Assert: Verifies that the process is terminated by the utility.

2.	Test Name: ProcessMonitor_DisplaysProcessKilledMessage_WhenMaxLifetimeExceeded
    •	Purpose: Verifies that the process monitoring utility displays a specific message when it terminates a process due to exceeding its maximum lifetime.
    •	Arrange: Sets up a test process with a short maximum lifetime and initiates monitoring.
    •	Act: Allows the process to run for a duration longer than the maximum allowed.
    •	Assert: Ensures that the utility displays a message indicating that it killed the process.


3.	Test Name: ProcessMonitor_DoesNotKillProcess_WithinMaxLifetime
    •	Purpose: Confirms that the process monitoring utility refrains from terminating a process within its designated lifetime.
    •	Arrange: Prepares a test scenario with a maximum lifetime longer than the actual runtime for a process with a specific name.
    •	Act: Lets the process execute within its specified lifetime.
    •	Assert: Verifies that the utility does not terminate the process prematurely.


4.	Test Name: ProcessMonitor_ContinuesMonitoring_AfterOneProcessKilled
    •	Purpose: Verifies that the process monitoring utility persists in monitoring other processes even after terminating one.
    •	Arrange: Initiates multiple instances of a test process with a short maximum lifetime and a predefined name.
    •	Act: Allows one of the processes to surpass its maximum lifetime.
    •	Assert: Ensures that the utility terminates the exceeding process, records the relevant termination message, and continues monitoring for other processes.


5.	Test Name: ProcessMonitor_TerminatesMonitoring_WhenQKeyIsPressed
    •	Purpose: Validates that the process monitoring utility stops monitoring when the designated exit key is pressed.
    •	Arrange: Activates the process monitoring utility with a known process.
    •	Act: Presses the specified exit key ('q') during monitoring.
    •	Assert: Ensures that the utility stops monitoring for other processes.


6.	Test Name: ProcessMonitor_DisplaysClosingMessage_WhenQKeyIsPressed
    •	Purpose: Validates that the process monitoring utility displays a closing message when the user presses the designated exit key ('q').
    •	Arrange: Starts the process monitoring utility with a known process and monitoring parameters.
    •	Act: Presses the exit key ('q') during monitoring.
    •	Assert: Verifies that the utility generates the closing message.


7.	Test Name: ProcessMonitor_DisplaysInvalidInputErrorMessage_WhenNonQKeyIsPressed
    •	Purpose: Ensures that the process monitoring utility displays an error message when the user presses a non-'q' key.
    •	Arrange: Starts the process monitoring utility with a known process and monitoring parameters.
    •	Act: Presses a non-'q' key during monitoring.
    •	Assert: Confirms that the utility outputs an error message indicating that only the 'q' key is allowed for closing.


8.	Test Name: ProcessMonitor_ContinuesMonitoring_WhenNonQKeyIsPressed
    •	Purpose: Verifies that the process monitoring utility continues monitoring when the user presses a non-'q' key.
    •	Arrange: Starts the process monitoring utility with a known process and monitoring parameters.
    •	Act: Presses a non-'q' key during monitoring.
    •	Assert: Ensures that the utility continues monitoring for the specified process without interruption.

*/