# Branch Structure Diagram

This diagram illustrates the branching workflow for the sw-eng-project.

## Visual Branch Flow

```
┌─────────────────────────────────────────────────────────────┐
│                                                             │
│                          MAIN BRANCH                         │
│                     (Production Ready)                       │
│                                                             │
└────────────┬────────────────┬────────────────┬──────────────┘
             │                │                │
             ↑                ↑                ↑
             │                │                │
       Merge after      Merge after      Merge after
       testing          testing          testing
             │                │                │
             │                │                │
┌────────────┴──────┐  ┌──────┴──────┐  ┌──────┴─────────────┐
│                   │  │             │  │                    │
│   FRONT BRANCH    │  │ BACK BRANCH │  │    API BRANCH      │
│  (Frontend Work)  │  │(Backend Work)│  │   (API Work)       │
│                   │  │             │  │                    │
└─────────┬─────────┘  └──────┬──────┘  └──────┬─────────────┘
          │                   │                 │
          ↑                   ↑                 ↑
          │                   │                 │
    Merge after         Merge after       Merge after
    review              review            review
          │                   │                 │
          │                   │                 │
    ┌─────┴─────┐       ┌─────┴─────┐     ┌────┴──────┐
    │           │       │           │     │           │
    │ feature/  │       │ feature/  │     │ feature/  │
    │  login    │       │user-auth  │     │  users-   │
    │   -ui     │       │  -logic   │     │  endpoint │
    │           │       │           │     │           │
    └───────────┘       └───────────┘     └───────────┘
```

## Workflow Steps

### 1. Feature Development Flow

```
Developer → Create feature branch → Develop → Push → Create PR → Review → Merge to base
                                                                             (front/back/api)
```

### 2. Release to Production Flow

```
Development branch → Test → Create PR to main → Review (2 approvals) → Merge → Production
(front/back/api)
```

## Example Workflows

### Frontend Developer Workflow

```
1. git checkout front
2. git pull origin front
3. git checkout -b feature/new-dashboard
4. [Make changes]
5. git commit -m "Add new dashboard UI"
6. git push origin feature/new-dashboard
7. Create PR: feature/new-dashboard → front
8. After approval: Merge to front
9. After testing: Create PR front → main
```

### Backend Developer Workflow

```
1. git checkout back
2. git pull origin back
3. git checkout -b feature/user-service
4. [Make changes]
5. git commit -m "Implement user service"
6. git push origin feature/user-service
7. Create PR: feature/user-service → back
8. After approval: Merge to back
9. After testing: Create PR back → main
```

### API Developer Workflow

```
1. git checkout api
2. git pull origin api
3. git checkout -b feature/products-api
4. [Make changes]
5. git commit -m "Add products CRUD endpoints"
6. git push origin feature/products-api
7. Create PR: feature/products-api → api
8. After approval: Merge to api
9. After testing: Create PR api → main
```

## Branch Protection Levels

```
┌──────────────────────────────────────────────────────────┐
│                     MAIN BRANCH                          │
│  ⚠️ Highest Protection                                   │
│  • Requires 2 approvals                                  │
│  • All status checks must pass                           │
│  • Must be up to date                                    │
│  • Direct pushes blocked                                 │
└──────────────────────────────────────────────────────────┘
                           ↑
                           │
            ┌──────────────┼──────────────┐
            │              │              │
┌───────────┴───┐  ┌───────┴────┐  ┌──────┴────────┐
│  FRONT        │  │   BACK     │  │     API       │
│  🔒 Protected │  │ 🔒 Protected│  │  🔒 Protected │
│  • 1 approval │  │ • 1 approval│  │  • 1 approval │
│  • CI checks  │  │ • CI checks │  │  • CI checks  │
└───────────────┘  └────────────┘  └───────────────┘
        ↑                ↑                ↑
        │                │                │
┌───────┴──────┐  ┌──────┴─────┐  ┌──────┴──────┐
│  Feature     │  │  Feature   │  │  Feature    │
│  Branches    │  │  Branches  │  │  Branches   │
│  📝 Open     │  │  📝 Open   │  │  📝 Open    │
│  • No rules  │  │  • No rules│  │  • No rules │
└──────────────┘  └────────────┘  └─────────────┘
```

## Team Member Responsibilities

```
┌─────────────────────────────────────────────────────────────┐
│                    5-MEMBER TEAM STRUCTURE                   │
└─────────────────────────────────────────────────────────────┘

┌──────────────┐  ┌──────────────┐  ┌──────────────┐
│ Frontend Dev │  │ Frontend Dev │  │ Backend Dev  │
│              │  │              │  │              │
│ Works on:    │  │ Works on:    │  │ Works on:    │
│ front branch │  │ front branch │  │ back branch  │
└──────────────┘  └──────────────┘  └──────────────┘

┌──────────────┐  ┌──────────────┐
│  API Dev     │  │  Full Stack  │
│              │  │    / Lead    │
│ Works on:    │  │              │
│ api branch   │  │ Works on:    │
└──────────────┘  │ all branches │
                  │ Reviews PRs  │
                  └──────────────┘
```

## Merge Strategy Summary

```
Feature Branch
      ↓ (Pull Request + 1 approval)
Development Branch (front/back/api)
      ↓ (Thorough testing)
      ↓ (Pull Request + 2 approvals)
Main Branch (Production)
      ↓ (Auto-deploy if configured)
Production Environment
```

## When to Use Each Branch

| Branch | When to Create From | When to Merge To | Purpose |
|--------|---------------------|------------------|---------|
| `main` | N/A (base branch) | N/A | Production releases |
| `front` | From `main` initially | To `main` for releases | Frontend integration |
| `back` | From `main` initially | To `main` for releases | Backend integration |
| `api` | From `main` initially | To `main` for releases | API integration |
| `feature/*` | From front/back/api | To front/back/api | Individual features |
| `fix/*` | From front/back/api | To front/back/api | Bug fixes |
| `hotfix/*` | From `main` | To `main` + back to dev branches | Critical production fixes |

## Hotfix Workflow (Special Case)

For critical production bugs:

```
1. git checkout main
2. git pull origin main
3. git checkout -b hotfix/critical-bug
4. [Fix the bug]
5. git commit -m "Fix critical production bug"
6. git push origin hotfix/critical-bug
7. Create PR: hotfix/critical-bug → main (urgent)
8. After merge to main:
   - Create PR: main → front
   - Create PR: main → back
   - Create PR: main → api
   (to sync the hotfix back to development branches)
```

---

**Remember**: Keep it simple and clean! This structure supports smooth collaboration without overcomplication.
