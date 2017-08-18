using System;
using Engine.models;

namespace Engine.field
{
    public static class FieldFactory
    {
        private static Field field;
        private static Tile[,] tiles;

        public static Field MakeField(FieldTemplate template)
        {
            CheckParameters(template);
            CreateEmptyTiles(template);
            field = new Field(tiles);
            SetTraps(template);
            SetBeasts();
            SetHunters(template);
            return field;
        }

        private static void CreateEmptyTiles(FieldTemplate template)
        {
            tiles = new Tile[template.Width, template.Height];
            for (int i = 0; i < template.Width; i++)
            {
                for (int j = 0; j < template.Height; j++)
                {
                    tiles[i,j] = new Tile(Tile.TileType.Common);
                }
            }
        }

        private static void CheckParameters(FieldTemplate template)
        {
            if (template.Width == 1 || template.Height == 1)
                throw new Exception("Поле должно быть больше двух клеток в ширину и высоту");
            if (template.Width > FieldTemplate.MaxWidth)
                throw new Exception($"Поле должно быть не больше {FieldTemplate.MaxWidth} в ширину");
            if (template.Height > FieldTemplate.MaxHeight)
                throw new Exception($"Поле должно быть не больше {FieldTemplate.MaxHeight} в высоту");
            var size = template.Width * template.Height;
            if (template.HuntersCount + template.MonstersCount + template.TrapsCount >= size)
                throw new Exception("Размер поля слишком мал для заданного количества объектов");
        }

        private static void SetBeasts()
        {
            var beast = new Beast {Position = GetFreeRandomPosition()};
            field.AddMonster(beast);
        }

        private static void SetHunters(FieldTemplate template)
        {
            for (int i = 0; i < template.HuntersCount; i++)
            {
                var hunter = new Hunter {Position = GetFreeRandomPosition()};
                field.AddHunter(hunter);
            }
        }

        private static void SetTraps(FieldTemplate template)
        {
            for (int i = 0; i < template.TrapsCount; i++)
            {
                var freePosition = GetFreeRandomPosition();
                tiles[freePosition.x, freePosition.y].Type = Tile.TileType.Trap;
            }
        }

        private static Coordinate GetFreeRandomPosition()
        {
            if(!FieldContainsFreePositions())
                throw new Exception("На поле не хватает свободных клеток");
            do
            {
                var x = new Random().Next(0, field.Width);
                var y = new Random().Next(0, field.Height);
                var position = new Coordinate {x = x, y = y};
                if (field.IsPositionFreeToMove(position))
                    return position;
            } while (true);
        }

        private static bool FieldContainsFreePositions()
        {
            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height; j++)
                {
                    var tile = field.Tiles[i, j];
                    if (tile.Type == Tile.TileType.Common && tile.Character == null)
                        return true;
                }
            }
            return false;
        }
    }
}
