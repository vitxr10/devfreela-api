﻿using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project()
        {
            
        }

        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public ProjectPaymentStatusEnum PaymentStatus { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public void Start()
        {
            Status = ProjectStatusEnum.InProgress;
            StartedAt = DateTime.Now;
        }

        public void Finish()
        {
            Status = ProjectStatusEnum.Finished;
            FinishedAt = DateTime.Now;
        }

        public void Delete()
        {
            Status = ProjectStatusEnum.Cancelled;
        }

        public void SetPaymentPending()
        {
            PaymentStatus = ProjectPaymentStatusEnum.Pending;
            UpdatedAt = DateTime.Now;
        }

    }
}
