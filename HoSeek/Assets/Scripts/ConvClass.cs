    class StoryObject{
        public SingleScript[] scripts;
        public StoryObject(int num){
            scripts = new SingleScript[num];
        }
        public void SetScript(int n, SingleScript singleObj){
            scripts[n] = singleObj;
        }
        public SingleScript GetScript(int n){
            return scripts[n];
        }
        public int GetScriptLen(){
            return scripts.Length;
        }
    }
    
    enum ScriptType{
        NARR, 
        CHOICE,
        ILLUST_FULL,
        END_CONV
    }
    class SingleScript{
        ScriptType type;
        int illustNum;
        string content;
        int nextGoto;

        // 생성자
        public SingleScript(ScriptType type, int bgimgNum, int illustNum, int charNum, int charImgNum, string content, int nextGoto){
            this.type = type;
            this.illustNum = illustNum;
            this.content = content;
            this.nextGoto = nextGoto;
        }

        // Getter
        public ScriptType GetScriptType(){
            return type;
        }
        public string GetContent(){
            return content;
        }
        public int GetNextGoto(){
            return nextGoto;
        }
        public int GetIllustNum(){
            return illustNum;
        }
    }

    class ChoiceScript{
        int choiceMax;
        string[] choice = new string[4];
        int[] choiceGoto = new int[4];

        public ChoiceScript(int choiceMax, string[] choice, int[] choiceGoto){
            this.choiceMax = choiceMax;
            this.choice = choice;
            this.choiceGoto = choiceGoto;
        }

        public int GetChoiceMax(){
            return choiceMax;
        }
        public string GetChoice(int idx){
            return choice[idx];
        }
        public int GetChoiceGoto(int idx){
            return choiceGoto[idx];
        }
    }