var editor = monaco.editor.create(document.getElementById('container'), {
    value: ';Scripts will appear here once they are loaded.',
    language: 'bdsp',
    roundedSelection: false,
	scrollBeyondLastLine: false,
	readOnly: true,
	theme: 'vs-dark'
});