var editor = monaco.editor.create(document.getElementById('container'), {
    value: ';Scripts will appear here once they are loaded.',
    language: 'bdsp',
    roundedSelection: false,
	scrollBeyondLastLine: false,
	readOnly: true,
	theme: 'vs-dark'
});
var outputElem = document.getElementById('output');
var model = editor.getModel();
model.setEOL(monaco.editor.EndOfLineSequence.LF);
editor.onDidChangeModelContent(async (e) => {
	outputElem.innerHTML = JSON.stringify(editor.getValue());
});