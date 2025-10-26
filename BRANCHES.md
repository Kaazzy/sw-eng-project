# Branch Structure

This repository uses the following branch structure:

## Branches

- **main**: Main production branch for the project (already exists)
- **front**: Frontend development branch
- **back**: Backend development branch
- **api**: API development branch

## Purpose

These branches allow the team to work on different parts of the project independently:
- **main**: Contains stable, production-ready code
- **front**: For frontend development (UI, client-side code)
- **back**: For backend development (server-side logic)
- **api**: For API development and integration

## Creating the Branches

To create the required branches in the remote repository, run the following commands:

```bash
# Ensure you have the latest main branch
git fetch origin main

# Create and push the front branch
git checkout -b front origin/main
git push origin front

# Create and push the back branch
git checkout -b back origin/main
git push origin back

# Create and push the api branch
git checkout -b api origin/main
git push origin api
```

Alternatively, you can create all branches at once:

```bash
git fetch origin main
git push origin origin/main:refs/heads/front origin/main:refs/heads/back origin/main:refs/heads/api
```

## Workflow

Once the branches are created, developers should:
1. Create feature branches from the appropriate base branch (front, back, or api)
2. Work on their features
3. Create pull requests to merge back to the base branch
4. Periodically merge approved changes to main
