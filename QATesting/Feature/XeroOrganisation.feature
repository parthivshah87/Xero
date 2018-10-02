@XeroOrganisation
Feature: XeroOrganisation

Background: Open Browser and Login 
	Given I navigate to Xero login page and login 
	And I enter 2FA code 
	And I make sure user is logged in

Scenario Outline: Add ANZ(NZ) bank account inside any xero Organisation
Given Select a <menu> from menu
And Select Bank Accounts 
And Click on Add Bank Account button
And Select ANZ (NZ) from banklist 
And Enter the account details  <AccountName>,<AccountType>, <AccountNumber>
When I click on continue 
Then Account should be added successfully 

Examples: 
| Menu     | Bank Name | AccountName  | AccountType			  | AccountNumber     |
| Accounts | ANZ (NZ)  | Parthiv Shah | Everyday (day-to-day) | 013257  1230123122|
