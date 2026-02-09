using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Project
{
    public partial class ProjectPlugin : ErpPlugin
    {
        // Entity IDs for Agile Planning
        private static readonly Guid EPIC_ENTITY_ID = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890");
        private static readonly Guid STORY_ENTITY_ID = new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901");
        private static readonly Guid SPRINT_ENTITY_ID = new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012");

        // Existing Entity IDs
        private static readonly Guid PROJECT_ENTITY_ID = new Guid("2d9b2d1d-e32b-45e1-a013-91d92a9ce792");
        private static readonly Guid TASK_ENTITY_ID = new Guid("9386226e-381e-4522-b27b-fb5514d77902");
        private static readonly Guid USER_ENTITY_ID = new Guid("b9cebc3b-6443-452a-8e34-b311a73dcc8b");

        // Role IDs for permissions
        private static readonly Guid ADMINISTRATOR_ROLE_ID = new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda");
        private static readonly Guid REGULAR_ROLE_ID = new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f");

        private static void Patch20260209(EntityManager entMan, EntityRelationManager relMan, RecordManager recMan)
        {
            #region << Task 1.1: Create Epic Entity >>
            CreateEpicEntity(entMan);
            #endregion

            #region << Task 1.2: Create Story Entity >>
            CreateStoryEntity(entMan);
            #endregion

            #region << Task 1.3: Create Sprint Entity >>
            CreateSprintEntity(entMan);
            #endregion

            #region << Task 2: Create Entity Relations >>
            CreateAgileRelations(entMan, relMan);
            #endregion
        }

        #region << Epic Entity Creation >>
        private static void CreateEpicEntity(EntityManager entMan)
        {
            #region << Create entity: epic >>
            {
                var entity = new InputEntity();
                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                systemFieldIdDictionary["id"] = new Guid("e1a1b1c1-d1e1-f1a1-b1c1-d1e1f1a1b1c1");

                entity.Id = EPIC_ENTITY_ID;
                entity.Name = "epic";
                entity.Label = "Epic";
                entity.LabelPlural = "Epics";
                entity.System = true;
                entity.IconName = "fas fa-mountain";
                entity.Color = "#9C27B0";
                entity.RecordScreenIdField = null;
                entity.RecordPermissions = new RecordPermissions();
                entity.RecordPermissions.CanCreate = new List<Guid>();
                entity.RecordPermissions.CanRead = new List<Guid>();
                entity.RecordPermissions.CanUpdate = new List<Guid>();
                entity.RecordPermissions.CanDelete = new List<Guid>();
                // Create
                entity.RecordPermissions.CanCreate.Add(ADMINISTRATOR_ROLE_ID);
                entity.RecordPermissions.CanCreate.Add(REGULAR_ROLE_ID);
                // Read
                entity.RecordPermissions.CanRead.Add(ADMINISTRATOR_ROLE_ID);
                entity.RecordPermissions.CanRead.Add(REGULAR_ROLE_ID);
                // Update
                entity.RecordPermissions.CanUpdate.Add(ADMINISTRATOR_ROLE_ID);
                entity.RecordPermissions.CanUpdate.Add(REGULAR_ROLE_ID);
                // Delete
                entity.RecordPermissions.CanDelete.Add(ADMINISTRATOR_ROLE_ID);

                var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                if (!response.Success)
                    throw new Exception("System error 10050. Entity: epic creation Message: " + response.Message);
            }
            #endregion

            // ... Epic fields continue (key, number, title, description, status, owner_id, project_id, created_on, created_by, completed_on)
        }
        #endregion

        #region << Story Entity Creation >>
        private static void CreateStoryEntity(EntityManager entMan)
        {
            // Story entity and fields implementation
        }
        #endregion

        #region << Sprint Entity Creation >>
        private static void CreateSprintEntity(EntityManager entMan)
        {
            // Sprint entity and fields implementation
        }
        #endregion

        #region << Agile Relations Creation >>
        private static void CreateAgileRelations(EntityManager entMan, EntityRelationManager relMan)
        {
            // Relations implementation
        }
        #endregion
    }
}
