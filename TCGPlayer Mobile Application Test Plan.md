# Task 1
## TGPlayer Mobile Application Test Plan
### Intro:
##### The TCGPlayer mobile application is used to manage card collections, scan cards, provide fast and accurate pricing, and offers an online marketplace for buying and selling. This Test Plan identifies the items and features of the mobile app to be tested as well as the types of testing, human resource requirements, and risks associated with the plan.
----------------------------------------
##### 1 Test Strategy
1.1	Scope of Testing
- Features to be tested
    - Scan functionality

- Features not to be tested
    - All other features including: shop, collection, sell, and user profile.

1.2	Test Type
- Unit Testing

1.3	Test Cases ordered by priority
- Installation
    - Go to the App store, search for the TCGPlayer app, then download and install the application. Verify that the application can be launched from the mobile device.

- Scan feature meets UI requirements
    - All appropriate buttons, images, and displays are visible
- App scan feature is enabled
    - When the user is on the scan tab, the scan area box is displayed and is ready to perform a card scan.
- User scan conduct scan functionality
    - When a card is placed face up on top of a plain, white sheet of paper, the card is scanned.
- Scan is uploaded to server and card value is returned
- List entry options contains correct options

1.4 Risk and Issues
- Testers unfamiliar with app
- Project schedule too short

1.5	Test Logistics
- Who will test?
    - Victor
    
- When will test occur?
    - Upon approval of this Test Plan
##### 2 Test Objective
- To verify the scan functionality of the mobile application

##### 3 Test Criteria
	3.1 Suspension Criteria
	-Tester reports >=40% of test cases failed
	3.2 Exit Criteria
	-Run rate is 100%, pass rate is 90%

##### 4 Resource Planning
4.1 System Resources
- Database server
- Test tool
- Network 
- Computer
- Mobile device compatible with the application
	
4.2 Human Resources
- Test Manager: Manage the project
- Tester: Complete testing
- Developer: Make enhancements and fixes
##### 5 Test Environment
- Tester has mobile emulator to simulate application>internet>access to application server

##### 6 Schedule & Estimation
6.1 Project tasks and estimation
- Installation of mobile app: 10 minutes
- Verification of app version: 5 minutes
- Scan cards: 10 minutes
- Database updates: 1 hour

6.2 Schedule to complete tasks
- Allow 1 full day for testing
##### 7 Test Deliverables
- Before testing phase
	 - Test documents
    - Test design
- During the testing
    - Test tool
    - Emulator
    - Error logs
- After the testing cycles are complete
    - Test results and reports
    - Testing guidelines
    - Defect reports
    - Release notes

