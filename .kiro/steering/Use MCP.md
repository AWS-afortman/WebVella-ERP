---
inclusion: always
---
# WebVella ERP Documentation MCP

When working with this WebVella ERP codebase, use the `webvella-docs` MCP server to access comprehensive documentation.

## Available Tools

- `mcp_webvella_docs_list_documentation` - List all available documentation files by category
- `mcp_webvella_docs_search_documentation` - Search across documentation for specific terms
- `mcp_webvella_docs_get_document` - Retrieve full content of a specific documentation file
- `mcp_webvella_docs_get_entity_info` - Get detailed information about a specific entity (e.g., 'user', 'role')
- `mcp_webvella_docs_get_field_types` - Get documentation for all available field types
- `mcp_webvella_docs_get_architecture_overview` - Get high-level system architecture overview
- `mcp_webvella_docs_get_technical_debt_summary` - Get summary of technical debt issues
- `mcp_webvella_docs_get_plugin_info` - Get information about plugins (SDK, CRM, Project, Mail, Next, MicrosoftCDM)

## When to Use

- Before making changes to entities or fields, use `get_entity_info` to understand the current structure
- When implementing new features, use `get_architecture_overview` to understand system design
- When working with plugins, use `get_plugin_info` to understand plugin responsibilities and dependencies
- When unsure about field type capabilities, use `get_field_types` for reference
- Use `search_documentation` to find relevant docs for any WebVella-specific concept
