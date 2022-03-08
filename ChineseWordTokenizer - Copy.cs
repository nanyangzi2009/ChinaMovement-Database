using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;


class ChineseWordTokenizer {
    protected string[]  wordsMap; //dictionary
    /**
     * 遇到空格直接换行
     * @var bool
     */
    protected bool _spaceBreak = true;
    /**
     * 中文和字母分开
     * @var bool
     */
    protected bool _separatedFromLetters = false;
    
    public  ChineseWordTokenizer(string file=null, bool useCache=false,  string  delimiter="\n") {
        string cacheFile = file + ".cache";//"{$file}.cache".ord(delimiter[0]);

        if (useCache && File.Exists(cacheFile))
        {

            return this.setWords(unserialize(file_get_contents($cacheFile)));
        }else if(File.Exists(file)) {
            this.loadWords(file, useCache, delimiter);
        }
    }*/
    public ChineseWordTokenizer(string file = null, bool useCache = false, string delimiter = "\n")
    {
        string cacheFile = file + ".cache";//"{$file}.cache".ord(delimiter[0]);

        if (useCache && File.Exists(cacheFile))
        {

            return this.setWords(unserialize(file_get_contents($cacheFile)));
        }
        else if (File.Exists(file))
        {
            this.loadWords(file, useCache, delimiter);
        }
    }



    /**
     * 加载词库
     * @param $file
     * @param bool $useCache
     * @param string $delimiter
     * @return ChineseWordTokenizer
     */
    public string loadWords(string file, bool useCache = false, string delimiter = "\n")
    {
        

        string content = file_get_contents(file);
        string[] words = array_filter(array_map("trim", explode($delimiter, $content)));
        string[] wordsIndex = [];

        foreach ($words as $i => $word) {
            $wordsIndex[mb_strlen($word)][] = $word;
        }

        ksort($wordsIndex);

        if ($useCache) {
            file_put_contents($cacheFile, serialize($wordsIndex));
        }

        return this.setWords($wordsIndex);
    }

    /**
     * @param $words
     * @return $this
     */
    public void   setWords(string words) {
        this._wordsMap = words;
    }
    
    public bool  spaceBreak(b=null) {
         bool old = this._spaceBreak;
        
        if(null != $b){
            this._spaceBreak = $b;
        }
        
        return old;
    }
    
    public bool separatedFromLetters(WHAT b=null) {
        bool old = this._separatedFromLetters;
    
        if(null != b){
            this._separatedFromLetters = b;
        }
    
        return old;
    }

    /**
     * 进行分词
     * @param $text
     * @return array
     */

    public string[] computeArray(string text)
    {
        string[] result = null;

            foreach (text as item) {
                result = array_merge($result, this.compute($item));
            }

            return result;
    }
    public string  compute(string text) {

        string s1 = text.Trim();
        
        if (this._spaceBreak) {
            s1.Replace(" ", ",");
        }
        else
        {
            s1.Replace(" ", "");
        }
        
        char  [] replacement = {
            '！', '（', '）', '【', '】', '’', '‘', '“', '”', '。', '、', '、', '，', '；', '：',
            '！', '；', '＇', '．', '，', '＂', '［', '］',
            ',', '!', ';', ':', '\'', '[', ']', '(', ')', '{', '}','\t', '\n'
        };
        
        string [] s2 = s1.Split(replacement);
    
             
        string tmpText = s1;
        string [][] splitOutWords ;
        int splitHeadCount = 0;
        int len;
    
        while(len = mb_strlen(tmpText)) {
            for(int i=len; i>0; i--) {
                if(i == len) {
                    splitOutWords[len][splitHeadCount]= tmpText;
                } else {
                    splitOutWords[i][splitHeadCount]= mb_substr(tmpText, 0, i);
                }
            }
        
            for(int i=1; i<len; i++) {
                splitOutWords [len-i][i + splitHeadCount]= mb_substr($tmpText, i, len-i);
            }
        
            tmpText = mb_substr(tmpText, 1, len-2);
            splitHeadCount ++;
        }
    
        krsort($splitOutWords);
        $foundWords = [];
    
        foreach(splitOutWords as $len => $posWords) {
            foreach($posWords as $pos => $posWord) {
                if(!isset($splitOutWords[$len]) || !isset($splitOutWords[$len][$pos])) {
                    continue;
                }
            
                if(this._findWord($posWord)) {
                    $foundWords[$len][$pos] = $posWord;
                    this._removeRelativeWords($splitOutWords, $len, $pos);
                }
            }
        }
    
        $remainingWords = [];
        foreach($splitOutWords as $len => $posWords) {
            foreach($posWords as $pos => $posWord) {
                if(!isset($splitOutWords[$len]) || !isset($splitOutWords[$len][$pos])) {
                    continue;
                }
    
                if(this._separatedFromLetters) {
                    this._wordSeparatedFromLetters($remainingWords, $posWord, $len, $pos);
                } else {
                    $remainingWords[$len][$pos] = $posWord;
                }
                
                this._removeRelativeWords($splitOutWords, $len, $pos);
            }
        }
        
        return this._mergeResult($foundWords, $remainingWords);
    }
    
    protected function _wordSeparatedFromLetters(&$remainingWords, string word, int len, int pos) {
        $word = preg_replace("#([0-9a-z\. ']+)#i", "\n$1\n", word);
        $words = array_filter(array_map("trim", explode("\n", word)));
        
        foreach ($words as $i => $word) {
            int wordLen = mb_strlen($word);
            $remainingWords[wordLen] [$pos] = $word;
            $pos += $wordLen;
        }
    }
    
    
    /**
     * 匹配词库
     * @param $word
     * @return bool
     */
    protected bool  _findWord(string word) {
        string s1 = word.Trim();
    
        if( s1=="") {
            return false;
        }
    
        int len = s1.Length;
    
        if(!isset(this._wordsMap[len])) {
            return false;
        }
    
        return in_array($word, this._wordsMap[$len]);
    }
    
    /**
     * @param $ary
     * @param $len
     * @param $bpos
     */
    protected function _removeRelativeWords(&$ary, int len, $bpos) {
        foreach ($ary as $alen => $rows) {
            foreach ($rows as $apos => $row) {
                $aepos = $apos+$alen-1;
            
                if( ($apos >= $bpos && $apos < $bpos+$len)
                    || ($aepos >= $bpos && $aepos < $bpos+$len)
                    || ($bpos >= $apos && $bpos < $apos+$alen)) {
                    unset($ary[$alen][$apos]);
                
                    if(empty($ary[$alen])) {
                        unset($ary[$alen]);
                    }
                }
            }
        }
    }
    
    protected string [] _mergeResult(string[]foundWords, string[]remainingWords) {
         string [] result;
    
        foreach($foundWords as $i => $rows) {
            $rows = array_map(function($r) {return ['word' => $r, 'found' => 1];}, $rows);
            $result = $result + $rows;
        }
    
        foreach($remainingWords as $i => $rows) {
            $rows = array_map(function($r) {return ['word' => $r, 'found' => 0];}, $rows);
            $result = $result + $rows;
        }
    
        ksort(result);
        return result;
    }
}

[Serializable]
class WordsCache
{
    protected string wordsMap = "";
}

/*
$tokenizer = new ChineseWordTokenizer('data2.txt', true, "\t");
$tokenizer->separatedFromLetters(true);
$result = $tokenizer->compute(
    '中华人民共和国位于亚洲东部，太平洋西岸，是工人阶级领导的、以工农联盟为基础的人民民主专政的社会主义国家.
    中华人民共和国英文缩写为 PRC，全称为People\'s Republic of China.
    CHN是中国(CHINA)的缩写，CHN是在联合国注册的国家代码，国际会议、体育比赛等正式场合代表国家时都用这种统一的国家代码。在网络域名中则以.cn作为缩写
');

print_r($result);*/
