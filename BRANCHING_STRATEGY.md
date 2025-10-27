# Branching Strategy

This document outlines the branching strategy for the sw-eng-project ASP.NET application.

## Branch Structure

Our team uses a simple and clean branching strategy with four main branches:

### 1. `main` Branch
- **Purpose**: Production-ready code
- **Protection**: Should be protected; requires pull request reviews before merging
- **Updates**: Only merge from `front`, `back`, or `api` branches after thorough testing
- **Deployment**: Automatically deploys to production (when CI/CD is configured)

### 2. `front` Branch
- **Purpose**: Frontend development work
- **Focus**: UI/UX, client-side code, views, and frontend assets
- **Merges from**: Feature branches for frontend work
- **Merges to**: `main` branch after testing and code review

### 3. `back` Branch
- **Purpose**: Backend development work
- **Focus**: Business logic, data processing, services, and server-side functionality
- **Merges from**: Feature branches for backend work
- **Merges to**: `main` branch after testing and code review

### 4. `api` Branch
- **Purpose**: API development work
- **Focus**: REST APIs, controllers, API endpoints, and integration points
- **Merges from**: Feature branches for API work
- **Merges to**: `main` branch after testing and code review

## Workflow Guidelines

### For Team Members

1. **Starting New Work**
   ```bash
   # Choose the appropriate base branch based on your work type
   git checkout front    # for frontend work
   git checkout back     # for backend work
   git checkout api      # for API work
   
   # Create a feature branch
   git checkout -b feature/your-feature-name
   ```

2. **While Working**
   - Commit frequently with clear, descriptive messages
   - Keep your feature branch up to date with the base branch:
   ```bash
   git fetch origin
   git merge origin/front  # or back/api depending on your base
   ```

3. **Completing Your Work**
   - Push your feature branch to remote
   - Create a pull request to merge into the appropriate branch (front/back/api)
   - Request code review from team members
   - Address review comments
   - Once approved, merge into the base branch

4. **Merging to Main**
   - After thorough testing on `front`, `back`, or `api` branch
   - Create a pull request from your branch to `main`
   - Require at least 1-2 team member approvals
   - Run all tests before merging
   - Merge to `main` only when ready for production

### Branch Protection Rules (Recommended)

To maintain code quality, configure these protection rules on GitHub:

#### For `main` branch:
- Require pull request reviews before merging (at least 2 approvals)
- Require status checks to pass before merging
- Require branches to be up to date before merging
- Do not allow direct pushes

#### For `front`, `back`, `api` branches:
- Require pull request reviews before merging (at least 1 approval)
- Require status checks to pass before merging
- Allow team members to merge after approval

## Common Scenarios

### Scenario 1: Developing a New Frontend Feature
```bash
git checkout front
git pull origin front
git checkout -b feature/new-login-page
# Make your changes
git add .
git commit -m "Add new login page with improved UX"
git push origin feature/new-login-page
# Create PR: feature/new-login-page → front
```

### Scenario 2: Fixing a Backend Bug
```bash
git checkout back
git pull origin back
git checkout -b fix/user-authentication-bug
# Fix the bug
git add .
git commit -m "Fix user authentication validation issue"
git push origin fix/user-authentication-bug
# Create PR: fix/user-authentication-bug → back
```

### Scenario 3: Adding a New API Endpoint
```bash
git checkout api
git pull origin api
git checkout -b feature/user-profile-endpoint
# Implement the endpoint
git add .
git commit -m "Add GET /api/users/:id/profile endpoint"
git push origin feature/user-profile-endpoint
# Create PR: feature/user-profile-endpoint → api
```

### Scenario 4: Releasing to Production
```bash
# After thorough testing on front/back/api branches
# Create PR: front → main (for frontend release)
# Create PR: back → main (for backend release)
# Create PR: api → main (for API release)
# Or merge all three if releasing a complete feature
```

## Best Practices

1. **Keep Branches Clean**
   - Delete feature branches after merging
   - Regularly sync with base branches to avoid large merge conflicts

2. **Meaningful Commit Messages**
   - Use present tense: "Add feature" not "Added feature"
   - Be descriptive: "Fix login button alignment on mobile" not "Fix bug"

3. **Small, Focused Changes**
   - Keep pull requests small and focused on a single feature or fix
   - Makes code review easier and faster

4. **Regular Communication**
   - Announce when you're working on a major feature
   - Communicate before merging to `main`
   - Use pull request descriptions to explain your changes

5. **Testing**
   - Test your changes locally before pushing
   - Ensure all tests pass before creating a pull request
   - Add new tests for new functionality

## Quick Reference

| Branch | Purpose | Base for Features | Merges To |
|--------|---------|-------------------|-----------|
| `main` | Production code | N/A | N/A (receives merges) |
| `front` | Frontend work | Feature branches | `main` |
| `back` | Backend work | Feature branches | `main` |
| `api` | API work | Feature branches | `main` |

## Setting Up Your Local Repository

```bash
# Clone the repository
git clone https://github.com/Kaazzy/sw-eng-project.git
cd sw-eng-project

# Fetch all branches
git fetch --all

# Set up tracking for remote branches
git checkout -b front origin/front
git checkout -b back origin/back
git checkout -b api origin/api
git checkout -b main origin/main

# Verify all branches are available
git branch -a
```

## Need Help?

If you're unsure which branch to use or have questions about the workflow:
1. Check this document first
2. Ask in the team chat
3. Consult with a senior team member
4. When in doubt, create a feature branch and ask for guidance in your pull request

---

**Remember**: This strategy is designed to keep our workflow simple and clean. Follow it consistently to ensure smooth collaboration across our 5-member team.
