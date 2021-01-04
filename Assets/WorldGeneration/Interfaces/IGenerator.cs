using System.Collections.Generic;
using Assets.Scripts.DTO;

namespace Assets.WorldGeneration.Interfaces
{
    public interface IGenerator
    {
        List<BlockDto> GetBlocksDto();
    }
}
