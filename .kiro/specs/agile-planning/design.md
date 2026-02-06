# Design Document: Agile Planning

## Overview

This design document describes the technical implementation of Agile Planning capabilities for the WebVella ERP Project Management plugin. The feature extends the existing Project plugin (`WebVella.Erp.Plugins.Project`) to support agile methodologies including Epics, Stories, Sprints, and Fibonacci story point estimation.

The implementation follows WebVella ERP patterns:
- Entity-based data modeling with PostgreSQL
- Plugin patch files for database migrations
- Service classes for business logic
- Hook system for record lifecycle events
- EQL (Entity Query Language) for data queries

## Architecture

The agile planning feature integrates into the existing Project plugin architecture.

## Components and Interfaces

### Entity Definitions

#### Epic Entity

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| id | GuidField | Yes | Primary key (auto-generated) |
| key | TextField | Yes | Unique key (e.g., PROJ-E1) |
| number | AutoNumberField | Yes | Sequential number per project |
| title | TextField | Yes | Epic title |
| description | HtmlField | No | Rich text description |
| status | SelectField | Yes | Draft, Active, Completed, Cancelled |
| owner_id | GuidField | No | Reference to user entity |
| project_id | GuidField | Yes | Reference to project entity |
| created_on | DateTimeField | Yes | Creation timestamp |
| created_by | GuidField | Yes | Creator user reference |
| completed_on | DateTimeField | No | Completion timestamp |

#### Story Entity

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| id | GuidField | Yes | Primary key (auto-generated) |
| key | TextField | Yes | Unique key (e.g., PROJ-S1) |
| number | AutoNumberField | Yes | Sequential number per project |
| title | TextField | Yes | Story title |
| description | HtmlField | No | Rich text description |
| acceptance_criteria | HtmlField | No | Acceptance criteria |
| status | SelectField | Yes | Draft, Ready, In Progress, In Review, Done, Cancelled |
| story_points | SelectField | No | Fibonacci: 1, 2, 3, 5, 8, 13, 21 |
| priority | NumberField | Yes | Numeric priority for ordering |
| owner_id | GuidField | No | Reference to user entity |
| project_id | GuidField | Yes | Reference to project entity |
| epic_id | GuidField | No | Reference to epic entity |
| sprint_id | GuidField | No | Reference to sprint entity |
| created_on | DateTimeField | Yes | Creation timestamp |
| created_by | GuidField | Yes | Creator user reference |
| completed_on | DateTimeField | No | Completion timestamp |

#### Sprint Entity

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| id | GuidField | Yes | Primary key (auto-generated) |
| name | TextField | Yes | Sprint name |
| goal | HtmlField | No | Sprint goal description |
| status | SelectField | Yes | Planning, Active, Completed, Cancelled |
| start_date | DateField | Yes | Sprint start date |
| end_date | DateField | Yes | Sprint end date |
| project_id | GuidField | Yes | Reference to project entity |
| created_on | DateTimeField | Yes | Creation timestamp |
| created_by | GuidField | Yes | Creator user reference |
| completed_on | DateTimeField | No | Completion timestamp |
