#pragma once
#include <iostream>
#include <stack>
using namespace std;

class clsMyString
{

    stack<string> _ValueUndoStack;
    stack<string> _ValueRedoStack;
    string _Value;

public:

    clsMyString(string Value = "")
    {
        _Value = Value;
        _ValueUndoStack.push(_Value);
    }

    void SetValue(string Value) {
        _Value = Value;
        _ValueUndoStack.push(Value);
    }

    string GetValue()
    {
        return _Value;
    }

    __declspec(property(get = GetValue, put = SetValue)) string Value;

    void Undo()
    {
        if (_ValueUndoStack.empty()) return;

        _ValueRedoStack.push(_Value);

        _ValueUndoStack.pop();
        _Value = _ValueUndoStack.top();
    }

    void Redo()
    {
        if (_ValueRedoStack.empty()) return;

        _ValueUndoStack.push(_ValueRedoStack.top());

        _ValueRedoStack.pop();
        _Value = _ValueUndoStack.top();

    }
};

