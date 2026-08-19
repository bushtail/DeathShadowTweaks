using JetBrains.Annotations;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Tables;

namespace DeathShadowTweaks;

[Injectable(TypePriority = OnLoadOrder.TraderRegistration - 1), UsedImplicitly]
public class DeathShadowTweaks(TemplateTable templateTable) : IOnLoad
{
    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        var itemsTemplate = templateTable.Items;

        foreach (var item in itemsTemplate)
        {
            if (item.Value.Name == null) { continue; }

            if (item.Value.Name.StartsWith("item_equipment_facecover_strikeball_mask"))
            {
                item.Value.Properties?.ConflictingItems = [];
            }
        }
        
        return Task.CompletedTask;
    }
}