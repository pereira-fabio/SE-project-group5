using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board board { get; private set; }
    public Vector3Int position { get; private set; }
    public TetrominoData data { get; private set; }
    public Vector3Int[] cells { get; private set; }
    public int rotationIndex { get; private set; }

    public float stepDelay = 1f;
    public float lockDelay = 0.5f;

    private float stepTime; 
    private float lockTime;

    public void Initialize(Board board, Vector3Int position, TetrominoData data)
    {
        this.board = board;
        this.position = position;
        this.data = data;
        this.rotationIndex = 0;
        this.stepTime = Time.time + this.stepDelay;
        this.lockTime = 0f;

        if (this.cells == null)
        {
            this.cells = new Vector3Int[data.cells.Length];
        }

        for (int i = 0; i < data.cells.Length; i++)
        {
            this.cells[i] = (Vector3Int)data.cells[i];
        }
    }

    public void Update(){
        this.board.Clear(this);
        this.lockTime += Time.deltaTime;
        UpdateSpeed();

        if(Input.GetKeyDown(KeyCode.Q)){//left rot
            Rotate(-1);
        }else if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.UpArrow)){// right rot 
            Rotate(1);
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            Move(Vector2Int.left);
        }else if (Input.GetKeyDown(KeyCode.D) ||Input.GetKeyDown(KeyCode.RightArrow)){
            Move(Vector2Int.right);
        }

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            Move(Vector2Int.down);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            HardDrop();
        }

        if (Time.time >= this.stepTime)
        {
            Step();
        }

        this.board.Set(this);
    }
    public void UpdateSpeed(){
        if(board.clearedLines >= 10){
            SetStepDelay(0.9f);
        } else if(board.clearedLines >= 20 && board.clearedLines < 30){
            SetStepDelay(0.8f);
        } else if(board.clearedLines >= 30 && board.clearedLines < 40){
            SetStepDelay(0.7f);
        } else if(board.clearedLines >= 40 && board.clearedLines < 50){
            SetStepDelay(0.6f);
        } else if(board.clearedLines >= 50 && board.clearedLines < 60){
            SetStepDelay(0.5f);
        } else if(board.clearedLines >= 60 && board.clearedLines < 70){
            SetStepDelay(0.4f);
        } else if(board.clearedLines >= 70 && board.clearedLines < 80){
            SetStepDelay(0.3f);
        } else if(board.clearedLines >= 80 && board.clearedLines < 90){
            SetStepDelay(0.2f);
        } else if(board.clearedLines >= 90 && board.clearedLines < 100){
            SetStepDelay(0.1f);
        } else if(board.clearedLines >= 100){
            SetStepDelay(0.05f);
        }
    }

    public void Step(){
        this.stepTime = Time.time + this.stepDelay;
        Move(Vector2Int.down);

        if(this.lockTime >= this.lockDelay){
            Lock();
        }
    }

    public void SetStepDelay(float delay){
        this.stepDelay = delay;
    }

    public void Lock(){
        this.board.Set(this);
        this.board.ClearLines();
        this.board.SpawnPiece();
    }

    public void HardDrop(){
        //will do the down movement as lonf it hit the fist thing 
        while (Move(Vector2Int.down))
        {
            continue;
        }
        Lock();
    }

    private bool Move(Vector2Int translation){
        Vector3Int newPos = this.position;
        newPos.x += translation.x;
        newPos.y += translation.y;

        bool valid = this.board.IsValidPos(this,newPos);

        if(valid){
            this.position = newPos;
            this.lockTime = 0f;
        }

        return valid;
    }

    public void Rotate(int direction){
        int originalRotation = this.rotationIndex;
        this.rotationIndex = Wrap(this.rotationIndex + direction, 0 , 4);

        ApplyRotationMatrix(direction);

        if(!TestWallKicks(this.rotationIndex, direction)){
            this.rotationIndex = originalRotation;
            ApplyRotationMatrix(-direction);
        }
    }

    public void ApplyRotationMatrix(int direction){
        for (int i = 0; i < this.cells.Length; i++)
        {
            Vector3 cell = this.cells[i];

            int x,y;

            switch(this.data.tetromino){
                case Tetromino.I:
                case Tetromino.O:
                    cell.x -= 0.5f;
                    cell.y -= 0.5f;

                    x = Mathf.CeilToInt((cell.x * Data.RotationMatrix[0] * direction ) + (cell.y * Data.RotationMatrix[1] * direction));
                    y = Mathf.CeilToInt((cell.x * Data.RotationMatrix[2] * direction ) + (cell.y * Data.RotationMatrix[3] * direction));
                    break;
                default:
                    x = Mathf.RoundToInt((cell.x * Data.RotationMatrix[0] * direction ) + (cell.y * Data.RotationMatrix[1] * direction));
                    y = Mathf.RoundToInt((cell.x * Data.RotationMatrix[2] * direction ) + (cell.y * Data.RotationMatrix[3] * direction));
                    break;
            }

            this.cells[i] = new Vector3Int(x, y, 0);
        }

    }

    public bool TestWallKicks(int rotationIndex, int roationDirection){
        int wallkickIndex = GetWallKicksIndex(rotationIndex, roationDirection);

        for (int i = 0; i < this.data.wallkicks.GetLength(1); i++)
        {
            Vector2Int translation = this.data.wallkicks[wallkickIndex, i];
            if (Move(translation))
            {
                return true;
            }
        }
        return false;
    }

    private int GetWallKicksIndex(int rotationIndex, int roationDirection){
        int wallkickIndex = rotationIndex * 2;

        if (roationDirection < 0)
        {
            wallkickIndex--;
        }
        return Wrap(wallkickIndex, 0, this.data.wallkicks.GetLength(0));
    }

    // makes sure that the roation does not accure out of bounds
    private int Wrap(int input, int min, int max)
    {
        if (input < min) {
            return max - (min - input) % (max - min);
        } else {
            return min + (input - min) % (max - min);
        }
    }
}
