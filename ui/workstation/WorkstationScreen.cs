using Godot;

namespace PleaseReturntheRobot;

public partial class WorkstationScreen : Control
{
    // Node assignments
    [Export] private CodeEdit _editor;
    [Export] private Button _runButton;

    [Signal] public delegate void RunRequestedEventHandler(string source);

    public override void _Ready()
    {
        _runButton.Pressed += () => EmitSignal(SignalName.RunRequested, _editor.Text);

        _editor.HighlightCurrentLine = true;

        // A highlighter belongs to one CodeEdit, so create one per terminal instance.
        CodeHighlighter highlighter = new()
        {
            FunctionColor = _editor.GetThemeColor("syntax_function_color"),
            NumberColor = _editor.GetThemeColor("syntax_number_color"),
            SymbolColor = _editor.GetThemeColor("syntax_symbol_color"),
            MemberVariableColor = _editor.GetThemeColor("syntax_member_color")
        };

        // TODO: basic Lua highlighting; replace these rules when LuaLS tokens are integrated.
        Color keywordColor = _editor.GetThemeColor("syntax_keyword_color");
        foreach (string keyword in new[]
        {
            "and", "break", "do", "else", "elseif", "end", "false", "for",
            "function", "goto", "if", "in", "local", "nil", "not", "or",
            "repeat", "return", "then", "true", "until", "while"
        })
        {
            highlighter.AddKeywordColor(keyword, keywordColor);
        }

        Color commentColor = _editor.GetThemeColor("syntax_comment_color");
        Color stringColor = _editor.GetThemeColor("syntax_string_color");
        highlighter.AddColorRegion("--[[", "]]", commentColor);
        highlighter.AddColorRegion("--", "", commentColor, true);
        highlighter.AddColorRegion("[[", "]]", stringColor);
        highlighter.AddColorRegion("\"", "\"", stringColor, true);
        highlighter.AddColorRegion("'", "'", stringColor, true);

        _editor.SyntaxHighlighter = highlighter;
    }

    public void Open()
    {
        Show();
        _editor.GrabFocus();
    }

    public void Close()
    {
        _editor.ReleaseFocus();
        Hide();
    }
}
