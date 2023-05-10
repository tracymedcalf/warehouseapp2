namespace WarehouseApp2.Models;

using RulesEngine;
using RulesEngine.Models;
using System.Dynamic;

public class RuleManager
{

    private static string AssignSKU = "Assign SKU";

    private RulesEngine Engine { get; set; }

    private Workflow CreateAssignWorkflow() {
        Workflow workflow = new();

        workflow.WorkflowName = AssignSKU;

        List<Rule> rules = new();

        Rule rule = new();
        rule.RuleName = "MHE Pick?";
        rule.SuccessEvent = "true";
        rule.ErrorMessage = "too small";
        rule.Expression = "weight < 150";

        rules.Add(rule);
        
        workflow.Rules = rules;

        return workflow;
    }

    public RuleManager() {

        List<Workflow> workflows = new();
        workflows.Add(CreateAssignWorkflow());

        Engine = new RulesEngine(workflows.ToArray(), null); 
    }

    public void AssignSku(Sku sku, IEnumerable<PickLocation> locations)
    {
        dynamic datas = new ExpandoObject();
        datas.weight = 1; 
        var inputs = new dynamic[] {
            datas
        };
        
        List<RuleResultTree> resultList = Engine.ExecuteAllRulesAsync(
                AssignSKU,
                inputs
                ).Result;

        bool outcome = false;

        outcome = resultList.TrueForAll(r => r.IsSuccess);
        Console.WriteLine($"Outcome = {outcome}");
    }
}
