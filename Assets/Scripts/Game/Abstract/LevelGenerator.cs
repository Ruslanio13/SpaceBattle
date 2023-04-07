using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private float _tileWidth;
    [SerializeField] private float _tileLength;

    [SerializeField] private LevelPreset def;

    private List<int> _lines;
    private List<GameObject> _walls;
    private int _minLen;
    private int _maxLen;
    
    private List<Tuple<int, int>> _freeSpots;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Generate(def);
    }

    public void Generate(LevelPreset preset)
    {
        _walls = preset.Walls;
        _lines = preset.Lines;
        _minLen = preset.MinLen;
        _maxLen = preset.MaxLen;
        
        _freeSpots = new List<Tuple<int, int>>();
        if (_lines.Count != _walls.Count)
            throw new Exception("Lines and walls lists in LevelGenerator are not the same size");

        for (int i = 0; i < _length; i++)
        for (int j = 0; j < _width; j++)
            _freeSpots.Add(new Tuple<int, int>(i, j));

        _freeSpots.Remove(new Tuple<int, int>(20, 0));
        _freeSpots.Remove(new Tuple<int, int>(20, 1));
        _freeSpots.Remove(new Tuple<int, int>(20, 2));
        _freeSpots.Remove(new Tuple<int, int>(20, 0));
        _freeSpots.Remove(new Tuple<int, int>(20, 1));
        _freeSpots.Remove(new Tuple<int, int>(20, 2));
        _freeSpots.Remove(new Tuple<int, int>(21, 0));
        _freeSpots.Remove(new Tuple<int, int>(21, 1));
        _freeSpots.Remove(new Tuple<int, int>(21, 2));
        _freeSpots.Remove(new Tuple<int, int>(22, 0));
        _freeSpots.Remove(new Tuple<int, int>(22, 1));
        _freeSpots.Remove(new Tuple<int, int>(22, 2));
        _freeSpots.Remove(new Tuple<int, int>(23, 0));
        _freeSpots.Remove(new Tuple<int, int>(23, 1));
        _freeSpots.Remove(new Tuple<int, int>(23, 2));

        for (int i = 0; i < _lines.Count; i++)
        {
            GenerateHorLine(_walls[i], _lines[i]);
            GenerateVertLine(_walls[i], _lines[i]);
        }
    }

    private void GenerateHorLine(GameObject wall, int amount)
    {
        GameObject newWall;
        Tuple<int, int> newPos;
        int rand;
        int length;
        for (int line = 0; line < amount; line++)
        {
            length = Random.Range(_minLen, _maxLen + 1);
            rand = Random.Range(0, _freeSpots.Count);
            newPos = _freeSpots[rand];
            for (int block = 0; block < length; block++)
            {
                newWall = Instantiate(wall);
                newWall.transform.position =
                    new Vector3((newPos.Item1 - _length / 2) * _tileLength, (newPos.Item2 - _width / 2) * _tileWidth);
                _freeSpots.Remove(newPos);

                if (newPos.Item1 != _length && _freeSpots.Contains(new Tuple<int, int>(newPos.Item1 + 1, newPos.Item2)))
                    newPos = new Tuple<int, int>(newPos.Item1 + 1, newPos.Item2);
                else if (newPos.Item1 != 0 && _freeSpots.Contains(new Tuple<int, int>(newPos.Item1 - 1, newPos.Item2)))
                    newPos = new Tuple<int, int>(newPos.Item1 - 1, newPos.Item2);
                else
                    break;
            }
        }
    }

    private void GenerateVertLine(GameObject wall, int amount)
    {
        GameObject newWall;
        Tuple<int, int> newPos;
        int rand;
        int length;
        for (int line = 0; line < amount; line++)
        {
            length = Random.Range(_minLen, _maxLen + 1);
            rand = Random.Range(0, _freeSpots.Count);
            newPos = _freeSpots[rand];
            for (int block = 0; block < length; block++)
            {
                newWall = Instantiate(wall);
                newWall.transform.position =
                    new Vector3((newPos.Item1 - _length / 2) * _tileLength, (newPos.Item2 - _width / 2) * _tileWidth);
                _freeSpots.Remove(newPos);

                if (newPos.Item2 != _width && _freeSpots.Contains(new Tuple<int, int>(newPos.Item1, newPos.Item2 + 1)))
                    newPos = new Tuple<int, int>(newPos.Item1, newPos.Item2 + 1);
                else if (newPos.Item2 != 0 && _freeSpots.Contains(new Tuple<int, int>(newPos.Item1, newPos.Item2 - 1)))
                    newPos = new Tuple<int, int>(newPos.Item1, newPos.Item2 - 1);
                else
                    break;
            }
        }
    }
}