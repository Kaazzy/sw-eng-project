# Contributing to sw-eng-project

Thank you for contributing to our ASP.NET project! This guide will help you get started.

## Getting Started

1. **Fork and Clone** (if external contributor) or **Clone** (if team member)
   ```bash
   git clone https://github.com/Kaazzy/sw-eng-project.git
   cd sw-eng-project
   ```

2. **Set Up Your Environment**
   - Install .NET SDK (version specified in project)
   - Install your preferred IDE (Visual Studio, VS Code, or Rider)
   - Install any required dependencies

3. **Understand Our Branching Strategy**
   - Read the [Branching Strategy Guide](BRANCHING_STRATEGY.md)
   - Understand which branch to use for your work

## Making Changes

### 1. Create a Feature Branch

Choose the appropriate base branch:

```bash
# For frontend work
git checkout front
git pull origin front
git checkout -b feature/your-feature-name

# For backend work
git checkout back
git pull origin back
git checkout -b feature/your-feature-name

# For API work
git checkout api
git pull origin api
git checkout -b feature/your-feature-name
```

### 2. Branch Naming Conventions

Use descriptive branch names with prefixes:

- `feature/` - New features (e.g., `feature/user-login`)
- `fix/` - Bug fixes (e.g., `fix/authentication-error`)
- `refactor/` - Code refactoring (e.g., `refactor/user-service`)
- `docs/` - Documentation updates (e.g., `docs/api-guide`)
- `test/` - Test additions/updates (e.g., `test/user-controller`)

### 3. Commit Messages

Write clear, descriptive commit messages:

**Good:**
```
Add user authentication endpoint

- Implement JWT token generation
- Add password hashing with BCrypt
- Include unit tests for auth service
```

**Bad:**
```
fix stuff
```

**Format:**
```
<type>: <short summary>

<detailed description>

<related issue/ticket if applicable>
```

### 4. Code Style

- Follow C# naming conventions (PascalCase for classes, camelCase for variables)
- Use meaningful variable and function names
- Add XML documentation comments for public methods
- Keep methods small and focused
- Follow SOLID principles

### 5. Testing

- Write unit tests for new functionality
- Ensure all tests pass before submitting PR
- Aim for high test coverage on critical paths

```bash
# Run tests
dotnet test
```

## Submitting Changes

### 1. Push Your Branch

```bash
git add .
git commit -m "Your descriptive commit message"
git push origin feature/your-feature-name
```

### 2. Create a Pull Request

1. Go to the repository on GitHub
2. Click "New Pull Request"
3. Select your branch → target branch (front/back/api)
4. Fill out the PR template:
   - **Title**: Clear, descriptive title
   - **Description**: What changes were made and why
   - **Testing**: How you tested the changes
   - **Screenshots**: If UI changes were made
5. Request review from team members
6. Link any related issues

### 3. Code Review Process

- Address all review comments
- Make requested changes in new commits
- Re-request review after changes
- Be open to feedback and suggestions
- Discuss disagreements respectfully

### 4. Merging

- Wait for required approvals (1-2 depending on branch)
- Ensure all CI checks pass
- Merge using the "Squash and merge" or "Merge commit" strategy (team preference)
- Delete your feature branch after merging

## Development Guidelines

### Frontend (front branch)

- Use consistent component structure
- Follow responsive design principles
- Optimize assets (images, CSS, JS)
- Test across different browsers
- Ensure accessibility standards

### Backend (back branch)

- Follow repository pattern for data access
- Implement proper error handling
- Use dependency injection
- Maintain separation of concerns
- Document business logic

### API (api branch)

- Follow RESTful conventions
- Use proper HTTP status codes
- Implement proper validation
- Document endpoints (Swagger/OpenAPI)
- Version your APIs appropriately

## Common Tasks

### Syncing Your Branch

```bash
# Update your local branch with latest changes
git checkout front  # or back/api
git pull origin front

# Update your feature branch
git checkout feature/your-feature-name
git merge front  # or back/api
```

### Resolving Merge Conflicts

1. Pull latest changes from base branch
2. Resolve conflicts in your editor
3. Mark conflicts as resolved:
   ```bash
   git add <resolved-files>
   git commit -m "Resolve merge conflicts"
   ```
4. Push changes

### Running the Project Locally

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run

# Run with hot reload
dotnet watch run
```

## Pull Request Checklist

Before submitting your PR, ensure:

- [ ] Code follows project style guidelines
- [ ] All tests pass locally
- [ ] New tests added for new functionality
- [ ] Documentation updated if needed
- [ ] Commit messages are clear and descriptive
- [ ] Branch is up to date with base branch
- [ ] No merge conflicts
- [ ] PR description is complete and clear

## Getting Help

- **Documentation Issues**: Check [Branching Strategy](BRANCHING_STRATEGY.md) and [README](README.md)
- **Technical Questions**: Ask in team chat or create a discussion
- **Bugs**: Create an issue with reproduction steps
- **Feature Ideas**: Discuss with the team before implementing

## Code of Conduct

- Be respectful and professional
- Welcome newcomers and help them learn
- Provide constructive feedback
- Focus on the code, not the person
- Keep discussions on-topic

## Review Timeline

- **Pull Requests**: Expect review within 1-2 business days
- **Urgent Fixes**: Tag as "urgent" and notify team
- **Complex Changes**: May require additional review time

## Release Process

1. **Feature Development**: Develop in feature branches → merge to front/back/api
2. **Integration Testing**: Test integrated features on front/back/api branches
3. **Production Release**: Create PR from front/back/api → main
4. **Deployment**: Main branch triggers production deployment (when configured)

---

Thank you for contributing! Your work helps make this project better for everyone. 🚀
