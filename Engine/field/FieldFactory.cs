using System;
using Engine.models;

namespace Engine.field
{
    public static class FieldFactory
    {
        private static Field field;
        private static FieldTemplate fieldTemplate;

        public static Field MakeField(FieldTemplate template)
        {
            fieldTemplate = template;
            CheckParameters();
            field = new Field(CreateEmptyTiles());
            SetTraps();
            SetCharacters();
            return field;
        }

        private static Tile[,] CreateEmptyTiles()
        {
            var tiles = new Tile[fieldTemplate.Width, fieldTemplate.Height];
            for (var i = 0; i < fieldTemplate.Width; i++)
            for (var j = 0; j < fieldTemplate.Height; j++)
                tiles[i, j] = new Tile(Tile.TileType.Common, new Coordinate(i, j));
            return tiles;
        }

        private static void CheckParameters()
        {
            if (fieldTemplate.Width == 1 || fieldTemplate.Height == 1)
                throw new Exception("Поле должно быть больше двух клеток в ширину и высоту");
            if (fieldTemplate.Width > FieldTemplate.MaxWidth)
                throw new Exception($"Поле должно быть не больше {FieldTemplate.MaxWidth} в ширину");
            if (fieldTemplate.Height > FieldTemplate.MaxHeight)
                throw new Exception($"Поле должно быть не больше {FieldTemplate.MaxHeight} в высоту");
            var size = fieldTemplate.Width * fieldTemplate.Height;
            if (fieldTemplate.HuntersCount + fieldTemplate.MonstersCount + fieldTemplate.TrapsCount >= size)
                throw new Exception("Размер поля слишком мал для заданного количества объектов");
        }

        private static void SetCharacters()
        {
            for (var i = 0; i < fieldTemplate.HuntersCount; i++)
            {
                var hunter = new Hunter {Position = GetFreeRandomPosition()};
                field.AddCharacter(hunter);
            }
            Character beast = fieldTemplate.SneakyBeast 
                ? new SneakyBeast {Position = GetFreeRandomPosition()} 
                : new Beast {Position = GetFreeRandomPosition()};
            field.AddCharacter(beast);
        }

        private static void SetTraps()
        {
            for (var i = 0; i < fieldTemplate.TrapsCount; i++)
            {
                var freePosition = GetFreeRandomPosition();
                field.GetTile(new Coordinate(freePosition.X, freePosition.Y)).Type = Tile.TileType.Trap;
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
                var position = new Coordinate(x, y);
                if (field.IsPositionBlank(position))
                    return position;
            } while (true);
        }

        private static bool FieldContainsFreePositions()
        {
            for (var i = 0; i < field.Width; i++)
            {
                for (var j = 0; j < field.Height; j++)
                {
                    var tile = field.GetTile(new Coordinate(i, j));
                    if (tile.Type == Tile.TileType.Common && tile.Character == null)
                        return true;
                }
            }
            return false;
        }
    }
}
