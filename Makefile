ifeq ($(OS),Windows_NT)
CLEAN_UP = if exist out (rd /s /q out) & if exist bin (rd /s /q bin) & if exist obj (rd /s /q obj) & if exist coverage.xml (del /q coverage.xml) & if exist dotCoverReport.html (del /q dotCoverReport.html) & if exist db (rd /s /q db)
else
CLEAN_UP = rm -rf out bin obj coverage.xml dotCoverReport.html db
endif

.PHONY: build run test coverage clean help

PROJECT_NAME=AspDotNetCrudProject.csproj
SOLUTION=AspDotNetCrudProject.sln

help:
	@echo Available commands:
	@echo   make build      - Restore and build the solution
	@echo   make run        - Run the application
	@echo   make test       - Run all tests in the solution
	@echo   make coverage   - Run tests with dotnet-coverage
	@echo   make dotcover   - Run tests with dotCover
	@echo   make clean      - Clean build artifacts

build:
	dotnet build $(SOLUTION)

run:
	dotnet run --project $(PROJECT_NAME)

test:
	dotnet test $(SOLUTION)

coverage:
	-dotnet tool install --global dotnet-coverage
	dotnet-coverage collect "dotnet test" -f xml -o coverage.xml

dotcover:
	-dotnet tool install --global JetBrains.dotCover.GlobalTool
	dotnet dotCover test --dcReportType=HTML --dcOutput=dotCoverReport.html

clean:
	dotnet clean
	$(CLEAN_UP)
	-mkdir db
