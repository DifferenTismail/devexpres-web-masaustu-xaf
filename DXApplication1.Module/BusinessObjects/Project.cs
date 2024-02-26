using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication1.Module.BusinessObjects
{
    [DefaultClassOptions]
    
    public class Project : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Project(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string _projectName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]

        public string ProjectName
        {
            get => _projectName;
            set => SetPropertyValue(nameof(ProjectName), ref _projectName, value);
        }

        Employee _assignedTo;
        [Association("Employee-Projects")]

        public Employee AssignedTo
        {
            get => _assignedTo;
            set => SetPropertyValue(nameof(AssignedTo), ref _assignedTo, value);
        }

        [Association("Project-ProjectTasks")]

        public XPCollection<ProjectTask> ProjectTasks
        {
            get
            {
                return GetCollection<ProjectTask>(nameof(ProjectTasks));
            }
        }

        Customer _customer;
        [Association("Customer-Projects")]
        
        public Customer Customer
        {
            get => _customer;
            set => SetPropertyValue(nameof(Customer), ref _customer, value);
        }

    }
}