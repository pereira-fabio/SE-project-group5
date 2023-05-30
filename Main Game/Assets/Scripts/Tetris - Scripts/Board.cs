using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
public class Board : MonoBehaviour
{
    public TetrominoData[] tetrominos;
    public Piece activePiece { get; private set; }
    public Piece nextPiece { get; private set; }  
    public Piece savedPiece { get; private set; } 

    public Tilemap tilemap { get; private set; }
    public Vector3Int spawnPosition;
    public Vector2Int boardSize = new Vector2Int(10,20);
    public Vector3Int previewPosition = new Vector3Int(-1, 12, 0); 
    public Vector3Int holdPosition = new Vector3Int(-1, 16, 0);

    public static int scoreOneLine = 40;
    public static int scoreTwoLine = 100;
    public static int scoreThreeLine = 300;
    public static int scoreFourLine = 1200;    
    public int currentScore = 0;
    public int clearedLines = 0;
    public int level = 1;
    public Text scoreText;
    public Text levelText;

    public bool gameOver = false;

    public GameObject GoPanel;
    public GameObject WPanel;
    public GameObject TetrisPanel;

    public RectInt Bounds{
        get{
            Vector2Int position = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y /2);
            return new RectInt(position, this.boardSize);
        }
    }


    private void Awake()
    {
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();

        nextPiece = gameObject.AddComponent<Piece>();
        nextPiece.enabled = false;

        savedPiece = gameObject.AddComponent<Piece>();
        savedPiece.enabled = false;

        for(int i = 0; i < this.tetrominos.Length; i++){
            this.tetrominos[i].Initialize();
        }
    }

    private void Start()
    {   
        gameOver = false;
        TetrisPanel.SetActive(true);
        GoPanel.SetActive(false);
        WPanel.SetActive(false);
        savedPiece.Initialize(this, holdPosition, tetrominos[0]);
        Set(savedPiece);
        Clear(savedPiece);
        
        SetNextPiece();
        SpawnPiece();
    }

    private void SetNextPiece()
    {
        // Clear the existing piece from the board
        if (nextPiece.cells != null) {
            Clear(nextPiece);
        }

        // Pick a random tetromino to use
        int random = Random.Range(0, tetrominos.Length);
        TetrominoData data = tetrominos[random];

        // Initialize the next piece with the random data
        // Draw it at the "preview" position on the board
        nextPiece.Initialize(this, previewPosition, data);
        Set(nextPiece);
    }
    
    public void SpawnPiece()
    {
        if (gameOver) {
            return;
        }
        // Initialize the active piece with the next piece data
        activePiece.Initialize(this, spawnPosition, nextPiece.data);

        // Only spawn the piece if valid position otherwise game over
        if (IsValidPos(activePiece, spawnPosition)) {
            Set(activePiece);
        } else {
            GameOver();
        }

        // Set the next random piece
        SetNextPiece();
    }

    public void SwapPiece()
    {
        // Temporarily store the current saved data so we can swap
        TetrominoData savedData = savedPiece.data;

        // Clear the existing piece from the board
        if (savedData.cells != null) {
            Clear(savedPiece);
        }

        // Store the next piece as the new saved piece
        // Draw this piece at the "hold" position on the board
        savedPiece.Initialize(this, holdPosition, activePiece.data);
        Set(savedPiece);

        if (savedData.cells != null)
        {
            Clear(activePiece);

            activePiece.Initialize(this, spawnPosition, savedData);
            Set(nextPiece);
        }
        
    }

    private void Update()
    {
        UpdateUI();
        SetLevel();
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
            SwapPiece();
        }
    }


    public void GameOver(){
        gameOver = true;
        GoPanel.SetActive(true);
        TetrisPanel.SetActive(false);
        WPanel.SetActive(false);
        level = 1;
        clearedLines = 0;
        currentScore = 0;
    }

    public void Victory(){
        StateValueConrtoller.stateValue +=30;
        gameOver = true;
        GoPanel.SetActive(false);
        TetrisPanel.SetActive(false);
        WPanel.SetActive(true);
        level = 1;
        clearedLines = 0;
        currentScore = 0;
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPos(Piece piece, Vector3Int position)
    {
        RectInt bounds = this.Bounds;

        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            if(!bounds.Contains((Vector2Int)tilePosition)){
                return false;
            }

            if(this.tilemap.HasTile(tilePosition)){
                return false;
            }
        }

        return true;
    }

    public void Points(int nbrOfRows){
        if(currentScore >= 1500){
            Victory();
        }

        if(nbrOfRows>0){
            if(nbrOfRows == 1){
                currentScore += scoreOneLine*level;
            } else if (nbrOfRows == 2){
                currentScore += scoreTwoLine*level;
            } else if (nbrOfRows == 3){
                currentScore += scoreThreeLine*level;
            } else if (nbrOfRows == 4){
                currentScore += scoreFourLine*level;
            }
        }
    }

    public void SetLevel(){
        if(clearedLines%10 == 0 && clearedLines != 0 && level < 11){
            level++;
            clearedLines = 0;
        }
        if(level == 11){
            level = 10;
            clearedLines = 1;
        }
    }
    public int GetLevel(){
        return level;
    }

    public void UpdateUI(){
        scoreText.text = currentScore.ToString();
        levelText.text = GetLevel().ToString();
    }

    public void ClearLines(){
        RectInt bounds = this.Bounds;
        int row = bounds.yMin;
        int nbrOfRows = 0;

        while (row < bounds.yMax)
        {
            if (IsLineFull(row))
            {
                LineClear(row);
                nbrOfRows++;
                clearedLines++;
            }else{
                row++;
            }
        }
        SetLevel();
        Points(nbrOfRows);
    }

    public bool IsLineFull(int row){
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            if (!this.tilemap.HasTile(position))
            {
                return false;
            }
        }
        return true;
    }

    public void LineClear(int row){
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++){
            Vector3Int position = new Vector3Int(col, row, 0);
            this.tilemap.SetTile(position, null);
        }

        while (row <bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++){
                Vector3Int position = new Vector3Int(col, row+1, 0); // row above
                TileBase above = this.tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(position, above);
            }
            row++;
        }
    }
}