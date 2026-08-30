---
name: github-code-review
description: 'Review GitHub pull requests for this repository. Use when asked to review a PR, inspect code-review findings, analyze a pull request diff, or identify regressions, security risks, and missing tests before merge.'
argument-hint: '[pull request number or URL]'
---

# GitHub Code Review

Review a pull request for merge-blocking defects, regressions, security issues, and missing verification. Focus on evidence from the diff and the code paths it changes rather than style preferences.

## Procedure

1. Identify the target pull request. Use the active pull request when no number or URL is provided.
2. Read the PR description, changed files, and the diff against its base branch.
3. Follow affected execution paths only far enough to determine behavioral impact. Check existing tests and project configuration that directly cover the changed behavior.
4. Validate claims where practical with the narrowest relevant test, build, lint, or typecheck command.
5. Report only actionable findings introduced by the pull request. Do not report pre-existing issues unless the pull request makes them worse.

## Finding Criteria

Report a finding when the change can cause incorrect behavior, a compatibility break, a security or data-loss risk, broken CI/release behavior, or insufficient tests for meaningful new or changed behavior.

Do not report subjective style preferences, formatting-only concerns, or hypothetical issues without a concrete affected path.

Use these priorities:

- `P0`: Immediate, widespread failure, data loss, or critical security issue.
- `P1`: Likely release-blocking defect or material regression.
- `P2`: Important but non-blocking correctness, maintainability, or coverage issue.
- `P3`: Minor, clearly actionable improvement.

## Response Format

Start with findings, ordered by priority. Each finding must include:

- Priority and a concise title
- The affected file and line link
- What fails and the concrete condition that triggers it
- Why it matters
- A focused correction, when apparent

Then state any open questions or assumptions. End with a brief change summary and the validation performed.

When no actionable findings exist, say so plainly and mention residual risk or test gaps, if any.
