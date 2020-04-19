using System.Threading.Tasks;
using dotnet_rpg.Dtos.Fight;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.FightService
{
    public interface IFightService
    {
         Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
    }
}