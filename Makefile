.PHONY: build run test coverage clean help

PROJECT_NAME=AspDotNetCrudProject.csproj
TEST_PROJECT=Tests/AspDotNetCrudProject.Tests.csproj
SOLUTION=AspDotNetCrudProject.sln

help:
	@echo "Available commands:"
	@echo "  make build      - Restore and build the solution"
	@echo "  make run        - Run the application"
	@echo "  make test       - Run all tests in the solution"
	@echo "  make coverage   - Run tests with dotnet-coverage"
	@echo "  make dotcover   - Run tests with dotCover"
	@echo "  make clean      - Clean build artifacts"

build:
	dotnet build $(SOLUTION)

run:
	dotnet run --project $(PROJECT_NAME)

test:
	dotnet test $(SOLUTION)

coverage:
	dotnet tool install --global dotnet-coverage || true
	dotnet-coverage collect "dotnet test" -f xml -o coverage.xml

dotcover:
	dotnet tool install --global JetBrains.dotCover.GlobalTool || true
	dotnet dotCover test --dcReportType=HTML --dcOutput=dotCoverReport.html

clean:
	dotnet clean
	rm -rf out bin obj coverage.xml dotCoverReport.html
