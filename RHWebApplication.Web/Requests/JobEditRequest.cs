﻿namespace RHWebApplication.Web.Requests;

public record JobEditRequest(int Id, string Title, string Description, bool IsUnhealthy, bool IsPericulosity, decimal BaseSalary);


