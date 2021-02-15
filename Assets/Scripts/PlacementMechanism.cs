using Assets.Scripts.DTO;
using Assets.WorldGeneration;

namespace Assets.Scripts
{
    public class PlacementMechanism
    {

        protected BlockInstanceGenerator blockGenerator;

        public PlacementMechanism()
        {
            blockGenerator = new BlockInstanceGenerator(ResourcePackManager.Instance.CreateResourcePack());
        }

        public void Place(BlockDto blockDto)
        {
            if (blockDto == null) return;
            if (blockDto.BlockId <= 0) return;
            if (blockDto.Position == default) return;
            blockGenerator.CreateBlockInstance(blockDto);
        }
    }
}