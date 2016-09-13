using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class scoreManager : MonoBehaviour {

	Dictionary<string, Dictionary<string, int>> playerScores;

    int changeCounter = 0;

	void Start() {

		setScore ("ME", "kills", 12);
		setScore ("ME", "scores", 240);

        setScore ("player_2", "kills", 3);
		setScore ("player_2", "scores", 60);

        setScore ("player_3", "kills", 4);
		setScore ("player_3", "scores", 80);

		setScore ("player_4", "kills", 0);
		setScore ("player_4", "scores", 0);

		setScore ("player_5", "kills", 1);
		setScore ("player_5", "scores", 20);

		setScore ("player_6", "kills", 12);
		setScore ("player_6", "scores", 240);

		setScore ("player_7", "kills", 8);
		setScore ("player_7", "scores", 160);

		setScore ("player_8", "kills", 0);
		setScore ("player_8", "scores", 0);

		setScore ("player_9", "kills", 1);
		setScore ("player_9", "scores", 20);

		setScore ("player_10", "kills", 12);
		setScore ("player_10", "scores", 240);

        //setScore("player_11", "kills", 100);
        //setScore("player_11", "scores", 2000);

	}

    void Update() {

    }

	void Init() {
		if (playerScores != null)
			return;

            playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

	public int getScore(string username, string scoreType) {
		Init ();

		if (playerScores.ContainsKey (username) == false) {
			return 0;
		}

		if (playerScores[username].ContainsKey (scoreType) == false) {
			return 0;
		}

		return playerScores [username] [scoreType];
	}

    public void setScore(string username, string scoreType, int value)
    {
        Init();

            changeCounter++;

            if (playerScores.ContainsKey(username) == false)
            {
                playerScores[username] = new Dictionary<string, int>();
            }

            playerScores[username][scoreType] = value;
    }

	public void changeScore(string username, string scoreType, int amount) {
		Init ();

        int currScore = getScore (username, scoreType);
		setScore (username, scoreType, currScore + amount);
	}

    public string[] getPlayerNames() {
        Init();

        return playerScores.Keys.ToArray();
    }

	public string [] getPlayerNames(string sortingScoreType){
		Init ();

        string[] names = playerScores.Keys.ToArray();
		return playerScores.Keys.OrderByDescending(n => getScore(n, sortingScoreType)).ToArray();
	}

	public void debug_add_kill_to_player1(){
            changeScore("ME", "kills", -1);
            changeScore("ME", "scores", -20);
	}

	public int getChangeCounter() {
		return changeCounter;
	}
}
