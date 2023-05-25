﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBoards.Entities
{
    public class WorkItem
    {
        public int Id { get; set; }


        //[Required]
        //public string State { get; set; }
        public WorkItemState State { get; set; }
        public int StateId { get; set; }


        //[Column(TypeName ="varchar(200)")]
        public string Area { get; set; }

        //[Column("Iteration_Path")]
        public string IterationPath { get; set; }
        public int Priority { get; set; }
        //Epic
        public DateTime? StartDate { get; set; }
        //[Precision(3)]
        public DateTime? EndDate { get; set; }
        //Issue
        //[Column(TypeName = "decimal(5,2)")]
        public decimal Effort { get; set; }
        //Task
        //[MaxLength(200)]
        public string Activity { get; set; }
        //[Precision(14,2)]
        public decimal RemainingWork { get; set; }
        public string Type { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
