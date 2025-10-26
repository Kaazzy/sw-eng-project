# sw-eng-project

ASP.NET Team Project - Simple and Clean Branch Structure

## Project Overview

This is an ASP.NET project developed by a 5-member team using a streamlined branching strategy to facilitate smooth collaboration.

## Branching Strategy

We use a simple 4-branch structure:
- **main**: Production-ready code
- **front**: Frontend development
- **back**: Backend development
- **api**: API development

### Documentation

- 📖 **[Branching Strategy Guide](BRANCHING_STRATEGY.md)** - Complete workflow instructions and best practices
- 📊 **[Branch Diagram](BRANCH_DIAGRAM.md)** - Visual representation of the workflow
- 🚀 **[Git Cheatsheet](GIT_CHEATSHEET.md)** - Quick reference for Git commands
- 🤝 **[Contributing Guide](CONTRIBUTING.md)** - How to contribute to the project
- ⚙️ **[Repository Setup](REPOSITORY_SETUP.md)** - For administrators only
- 🔧 **[Branch Initialization](BRANCH_INITIALIZATION.md)** - First-time setup guide

## Quick Start

```bash
# Clone the repository
git clone https://github.com/Kaazzy/sw-eng-project.git
cd sw-eng-project

# Fetch all branches
git fetch --all

# Check out the branch relevant to your work
git checkout front    # for frontend work
git checkout back     # for backend work
git checkout api      # for API work
```

## For New Team Members

1. Read the [Branching Strategy Guide](BRANCHING_STRATEGY.md)
2. Set up your local environment
3. Create feature branches from the appropriate base branch (front/back/api)
4. Submit pull requests for code review
5. Merge to main only after thorough testing

## Development Workflow

1. Pick a task from your project management tool
2. Create a feature branch from the appropriate base (front/back/api)
3. Develop and test your changes
4. Create a pull request for code review
5. Merge after approval
6. Deploy to production through the main branch

## Need Help?

- Check the [Branching Strategy Guide](BRANCHING_STRATEGY.md)
- Ask your team members
- Review existing pull requests for examples

---

**Keep it simple, keep it clean!**