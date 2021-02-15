using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Data_Models;
using Assets.Scripts.DTO;
using Assets.Scripts.Enums;
using Assets.StorageSystem.StorageProviders;
using Assets.WorldGeneration.Interfaces;
using UnityEngine;

namespace Assets.WorldGeneration
{
    public class BlockInstanceManager : MonoBehaviour
    {
        public static BlockInstanceManager Instance { get; private set; }

        public event System.Action OnWorldGenerated;
        public event System.Action<int> LoadingProgress; 

        private BlockInstanceGenerator _blockInstanceGenerator;

        private ResourcePack _resourcePack;

        private List<BlockDto> _allBlocks = new List<BlockDto>();
        private readonly List<BlockDto> _activeBlocks = new List<BlockDto>();

        private const int BLOCKS_PER_FRAME = 30;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            _resourcePack = ResourcePackStorageProvider.Instance.LoadResourcePack();
            _blockInstanceGenerator = new BlockInstanceGenerator(_resourcePack);
        }

        public void CreateSurroundBlocksIfPossible(BlockDto blockDto)
        {
            _allBlocks.Remove(blockDto);
            _activeBlocks.Remove(blockDto);
            var neighborsDict = GetBlockNeighbors(blockDto);

            foreach (var neighbor in neighborsDict)
            {
                if (neighbor.Value == null)
                {
                    continue;
                }
                var isExistInScene = _activeBlocks.Exists(t => t == neighbor.Value);
                if (!isExistInScene)
                {
                    _blockInstanceGenerator.CreateBlockInstance(neighbor.Value);
                    _activeBlocks.Add(neighbor.Value);
                }
            }
        }

        private void CreateBlockIfPossible(BlockDto blockDto)
        {
            var neighborsDict = GetBlockNeighbors(blockDto);

            foreach (var neighbor in neighborsDict)
            {
                if (neighbor.Value == null)
                {
                    _blockInstanceGenerator.CreateBlockInstance(blockDto);
                    _activeBlocks.Add(blockDto);
                    return;
                }
            }
        }

        private Dictionary<BlockNeighbor, BlockDto> GetBlockNeighbors(BlockDto blockDto)
        {
            return new Dictionary<BlockNeighbor, BlockDto>
            {
                {BlockNeighbor.Right, _allBlocks.FirstOrDefault(t =>
                    t.Position == new Vector3(blockDto.Position.x - 1, blockDto.Position.y, blockDto.Position.z)
                    )},

                {BlockNeighbor.Left, _allBlocks.FirstOrDefault(t =>
                    t.Position == new Vector3(blockDto.Position.x + 1, blockDto.Position.y, blockDto.Position.z)
                    )},

                {BlockNeighbor.Up, _allBlocks.FirstOrDefault(t => 
                    t.Position == new Vector3(blockDto.Position.x, blockDto.Position.y + 1, blockDto.Position.z)
                    )},

                {BlockNeighbor.Down, _allBlocks.FirstOrDefault(t => 
                    t.Position == new Vector3(blockDto.Position.x, blockDto.Position.y - 1, blockDto.Position.z)
                    )},

                {BlockNeighbor.Forward, _allBlocks.FirstOrDefault(t => 
                    t.Position == new Vector3(blockDto.Position.x, blockDto.Position.y, blockDto.Position.z + 1)
                )},

                {BlockNeighbor.Backward, _allBlocks.FirstOrDefault(t => 
                    t.Position == new Vector3(blockDto.Position.x, blockDto.Position.y, blockDto.Position.z - 1)
                )}
            };
        }

        public void GenerateWorld(IWorldGenerator generator)
        {
            StartCoroutine(GenerateWorldCoroutine(generator));
        }

        private IEnumerator GenerateWorldCoroutine(IWorldGenerator generator)
        {
            _allBlocks = generator.GetBlocksDto();
            var blockCountInFrame = 0;
            foreach (var block in _allBlocks)
            {
                CreateBlockIfPossible(block);
                blockCountInFrame++;
                if (blockCountInFrame >= BLOCKS_PER_FRAME)
                {
                    var currentIndex = _allBlocks.IndexOf(block);
                    var loadingProgress = currentIndex * 100 / _allBlocks.Count;
                    Debug.Log(loadingProgress);
                    LoadingProgress?.Invoke(loadingProgress);
                    blockCountInFrame = 0;
                    yield return null;
                }
            }
            OnWorldGenerated?.Invoke();
        }

        public void Combine()
        {
            _blockInstanceGenerator.Combine();
        }
    }
}
