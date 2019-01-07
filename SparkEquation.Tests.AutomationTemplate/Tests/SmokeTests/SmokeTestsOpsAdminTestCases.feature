Feature: SmokeTestsOpsAdminTestCases
	In order to avoid silly mistakes
	I want to check that basic application features are working as expected

@TC_1
Scenario: Authorization in testproject
	Given "LoginPage" is opened
	When I Login as OpsAdmin
