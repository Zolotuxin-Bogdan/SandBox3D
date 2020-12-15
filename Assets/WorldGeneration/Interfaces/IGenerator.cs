using System.Collections.Generic;
using UnityEngine;

public interface IGenerator
{
    List<BlockDto> GetBlocksDto();
}
