
If you see that:
- Does not compile
- Does not contain unit tests
- Unit tests are failing
Then contact me, please! This is some mistake then.

Steps:
	Build the solution
	Deploy SEM.Database
	Check connection string is pointing to the DB in SEM.Core, SEM, SEM.WcfServiceApplication projects
	For tests connection string use the same, but add -Test suffix
	update-database for SEM.Core
	F5 -should run site, service and application
	    SITE
		go to site, register with Publishing role checked (register as Publisher)
		as Publisher, go to Publications list and add one, upload a PDF file
		register without Publishing checked (User)
		subscribe to a publication[s] as User
		APP/WCF
		Alt+Tab to App and login with User credentials
	Ctrl R,A to run tests
