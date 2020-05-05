Feature: FillYesterdayTimesheet
	In case you missed filling timesheet yesterday, this feature will do it.

Background: 
Given login into portal

Scenario: Fill yesterday timesheet
Given check if timesheet is not present
Then Fill yesterday timesheet