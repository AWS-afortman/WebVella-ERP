# Requirements Document

## Introduction

This document defines the requirements for adding Agile Planning capabilities to the WebVella ERP Project Management plugin. The feature enables teams to manage Epics, Stories, and Tasks using agile methodologies, including Fibonacci story point estimation and sprint planning capabilities. This extends the existing Project plugin (WebVella.Erp.Plugins.Project) which already provides projects, milestones, tasks, and time tracking.

## Glossary

- **Agile_System**: The agile planning subsystem within the Project plugin that manages epics, stories, and agile workflows
- **Epic**: A large body of work that can be broken down into smaller stories; groups related user stories together
- **Story**: A user story representing a feature or requirement from the end-user perspective; belongs to an epic
- **Task**: An existing entity in the Project plugin representing a unit of work; can be linked to stories
- **Story_Point**: A relative measure of effort using the Fibonacci sequence (1, 2, 3, 5, 8, 13, 21)
- **Sprint**: A time-boxed iteration for completing a set of stories
- **Backlog**: A prioritized list of stories and epics awaiting implementation
- **Owner**: A user assigned responsibility for an epic, story, or task
- **Project**: An existing entity representing a project container for milestones, tasks, and now agile artifacts

## Requirements

### Requirement 1: Epic Management

**User Story:** As a product owner, I want to create and manage epics, so that I can organize related user stories into larger themes of work.

#### Acceptance Criteria

1. WHEN a user creates an epic, THE Agile_System SHALL store the epic with a unique identifier, title, description, status, and project association
2. WHEN a user edits an epic, THE Agile_System SHALL update the epic fields and persist the changes
3. WHEN a user deletes an epic, THE Agile_System SHALL remove the epic and disassociate any linked stories without deleting them
4. WHEN an epic is created, THE Agile_System SHALL generate a unique key in the format {PROJECT_ABBR}-E{NUMBER}
5. WHEN viewing an epic, THE Agile_System SHALL display the count of associated stories and their aggregate story points
6. THE Agile_System SHALL support epic statuses: Draft, Active, Completed, and Cancelled

### Requirement 2: Story Management

**User Story:** As a product owner, I want to create and manage user stories with acceptance criteria, so that I can define features from the user's perspective.

#### Acceptance Criteria

1. WHEN a user creates a story, THE Agile_System SHALL store the story with a unique identifier, title, description, acceptance criteria, status, and optional epic association
2. WHEN a user edits a story, THE Agile_System SHALL update the story fields and persist the changes
3. WHEN a user deletes a story, THE Agile_System SHALL remove the story and disassociate any linked tasks without deleting them
4. WHEN a story is created, THE Agile_System SHALL generate a unique key in the format {PROJECT_ABBR}-S{NUMBER}
5. THE Agile_System SHALL support story statuses: Draft, Ready, In Progress, In Review, Done, and Cancelled
6. WHEN a story status changes to Done, THE Agile_System SHALL record the completion timestamp

### Requirement 3: Story Point Estimation

**User Story:** As a team member, I want to estimate stories using Fibonacci story points, so that I can communicate relative effort consistently.

#### Acceptance Criteria

1. THE Agile_System SHALL provide story point values limited to the Fibonacci sequence: 1, 2, 3, 5, 8, 13, 21
2. WHEN a user assigns story points to a story, THE Agile_System SHALL validate the value is in the allowed Fibonacci sequence
3. IF a user attempts to assign an invalid story point value, THEN THE Agile_System SHALL reject the value and display an error message
4. WHEN viewing an epic, THE Agile_System SHALL calculate and display the sum of story points from all associated stories
5. THE Agile_System SHALL allow story points to be null for unestimated stories

### Requirement 4: Task-Story Linking

**User Story:** As a developer, I want to link existing tasks to stories, so that I can break down stories into actionable work items.

#### Acceptance Criteria

1. WHEN a user links a task to a story, THE Agile_System SHALL create a many-to-many relationship between the task and story
2. WHEN a user unlinks a task from a story, THE Agile_System SHALL remove the relationship without deleting either entity
3. WHEN viewing a story, THE Agile_System SHALL display all linked tasks with their status and owner
4. THE Agile_System SHALL allow a task to be linked to multiple stories
5. THE Agile_System SHALL allow a story to have multiple linked tasks

### Requirement 5: Owner Assignment

**User Story:** As a team lead, I want to assign owners to epics, stories, and tasks, so that I can track accountability and workload.

#### Acceptance Criteria

1. WHEN a user assigns an owner to an epic, THE Agile_System SHALL store the user reference and persist the assignment
2. WHEN a user assigns an owner to a story, THE Agile_System SHALL store the user reference and persist the assignment
3. THE Agile_System SHALL allow epics and stories to have no owner (null owner_id)
4. WHEN an owner is assigned, THE Agile_System SHALL validate the user exists in the system
5. WHEN viewing a backlog or sprint, THE Agile_System SHALL display owner information for each item

### Requirement 6: Backlog View

**User Story:** As a product owner, I want to view and prioritize the product backlog, so that I can manage the order of work.

#### Acceptance Criteria

1. WHEN a user views the backlog, THE Agile_System SHALL display all stories not assigned to a sprint, ordered by priority
2. THE Agile_System SHALL support a numeric priority field for ordering backlog items
3. WHEN a user changes a story's priority, THE Agile_System SHALL update the display order accordingly
4. WHEN viewing the backlog, THE Agile_System SHALL display story key, title, epic association, story points, status, and owner
5. THE Agile_System SHALL support filtering the backlog by epic, status, and owner

### Requirement 7: Sprint Management

**User Story:** As a scrum master, I want to create and manage sprints, so that I can plan time-boxed iterations for the team.

#### Acceptance Criteria

1. WHEN a user creates a sprint, THE Agile_System SHALL store the sprint with a unique identifier, name, start date, end date, goal, and project association
2. WHEN a user assigns stories to a sprint, THE Agile_System SHALL create a relationship between the story and sprint
3. WHEN a user removes a story from a sprint, THE Agile_System SHALL remove the relationship and return the story to the backlog
4. THE Agile_System SHALL support sprint statuses: Planning, Active, Completed, and Cancelled
5. WHEN viewing a sprint, THE Agile_System SHALL display the total story points and count of stories assigned
6. THE Agile_System SHALL prevent a story from being assigned to multiple active sprints simultaneously
7. WHEN a sprint is marked as Completed, THE Agile_System SHALL record the completion timestamp

### Requirement 8: Agile Navigation

**User Story:** As a user, I want dedicated navigation areas for agile planning, so that I can easily access epics, stories, sprints, and backlog views.

#### Acceptance Criteria

1. THE Agile_System SHALL add an "Agile" sitemap area to the Projects application
2. THE Agile_System SHALL provide navigation nodes for: Backlog, Sprints, Epics, and Stories
3. WHEN a user navigates to the Agile area, THE Agile_System SHALL display the appropriate list or detail pages
4. THE Agile_System SHALL integrate with the existing Projects application navigation structure

### Requirement 9: Data Persistence

**User Story:** As a system administrator, I want agile data to be persisted reliably, so that planning information is not lost.

#### Acceptance Criteria

1. THE Agile_System SHALL store all epic data in a PostgreSQL entity table named "epic"
2. THE Agile_System SHALL store all story data in a PostgreSQL entity table named "story"
3. THE Agile_System SHALL store all sprint data in a PostgreSQL entity table named "sprint"
4. WHEN serializing agile entities to JSON, THE Agile_System SHALL produce valid JSON that can be deserialized back to equivalent objects
5. FOR ALL valid epic, story, and sprint objects, serializing then deserializing SHALL produce an equivalent object (round-trip property)

### Requirement 10: Integration with Existing Project Plugin

**User Story:** As a developer, I want the agile features to integrate seamlessly with existing Project plugin entities, so that I can leverage existing functionality.

#### Acceptance Criteria

1. THE Agile_System SHALL create relationships between epics and the existing project entity
2. THE Agile_System SHALL create relationships between stories and the existing project entity
3. THE Agile_System SHALL create relationships between sprints and the existing project entity
4. THE Agile_System SHALL reuse the existing task entity for task-story linking
5. THE Agile_System SHALL follow WebVella ERP plugin patterns for entity creation, hooks, and services
6. THE Agile_System SHALL implement changes via dated patch files following the pattern ProjectPlugin.YYYYMMDD.cs
