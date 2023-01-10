class Command {
    constructor(id, name, description, dummy, animation, args) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.dummy = dummy;
        this.animation = animation;
        this.args = args;
    }
}

class Arg {
    constructor(name, description, type, optional) {
        this.name = name;
        this.description = description;
        this.type = type;
        this.optional = optional;
    }
}

class Flag {
    constructor(id, name, description) {
        this.id = id;
        this.name = name;
        this.description = description;
    }
}

class SystemFlag {
    constructor(id, name, description) {
        this.id = id;
        this.name = name;
        this.description = description;
    }
}

class WorkVariable {
    constructor(id, name, description) {
        this.id = id;
        this.name = name;
        this.description = description;
    }
}

var commands = [];
var flags = [];
var sysflags = [];
var works = [];

loadFiles('../JSON/commands.json', '../JSON/flags.json', '../JSON/sys_flags.json', '../JSON/work.json')
    .then(registerLanguageAndSyntax)
    .catch(function (err) {
        console.log('Error while loading JSON: ' + err);
    });

async function loadFiles(commandsFile, flagsFile, sysFlagsFile, workFile) {
    return fetch(commandsFile)
    .then(function (response) {
        return response.json();
    })
    .then(function (data) {
        handleCommands(data);
    }) &&
    fetch(flagsFile)
    .then(function (response) {
        return response.json();
    })
    .then(function (data) {
        handleFlags(data);
    }) &&
    fetch(sysFlagsFile)
    .then(function (response) {
        return response.json();
    })
    .then(function (data) {
        handleSysFlags(data);
    }) &&
    fetch(workFile)
    .then(function (response) {
        return response.json();
    })
    .then(function (data) {
        handleWork(data);
    });
}

function handleCommands(data) {
    for (var i = 0; i < data.length; i++) {
        var command = new Command(data[i].Id, data[i].Name, data[i].Description, data[i].Dummy, data[i].Animation, data[i].Args.map(a => new Arg(a.TentativeName, a.Description, a.Type, a.Optional)));
        commands.push(command);
    }
}

function handleFlags(data) {
    for (var i = 0; i < data.length; i++) {
        var flag = new Flag(data[i].Id, data[i].Name, data[i].Description);
        flags.push(flag);
    }
}

function handleSysFlags(data) {
    for (var i = 0; i < data.length; i++) {
        var sysFlag = new SystemFlag(data[i].Id, data[i].Name, data[i].Description);
        sysflags.push(sysFlag);
    }
}

function handleWork(data) {
    for (var i = 0; i < data.length; i++) {
        var work = new WorkVariable(data[i].Id, data[i].Name, data[i].Description);
        works.push(work);
    }
}

function buildCommandDescription(command) {
    var descriptionItems = [];
    if (command.animation) descriptionItems.push("[Animation command]");
    if (command.dummy) descriptionItems.push("This command is dummied out and does nothing.");
    else descriptionItems.push(command.description == "" ? "This command is not documented yet." : command.description);
    var description = descriptionItems.join(" ");
    var args = "";
    if (command.args.length == 0) args = "No arguments.";
    else
    {
        var args = command.args.map(a => {
            var types = a.type.join(", ");
            var optional = a.optional ? "(Optional) " : "";
            return "[" + types + "] **" + a.name + "** - " + optional + a.description;
        }).join('\n\n');
    }
    return description + "\n\n\n\nArguments:\n\n" + args;
}

function registerLanguageAndSyntax()
{
    monaco.languages.register({
        id: 'bdsp'
    });

    monaco.languages.setMonarchTokensProvider('bdsp', {
        commands: commands.map(c => c.name),
        flags: flags.map(f => f.name),
        sysflags: sysflags.map(s => s.name),
        works: works.map(w => w.name),

        // The main tokenizer for our languages
        tokenizer: {
            root: [
                // unrecognized cmds and args
                [/cmd_-?\d+/, 'keyword'],
                [/flag_-?\d+/, 'type.keyword'],
                [/sys_-?\d+/, 'annotation'],
                [/var_-?\d+/, 'regexp'],

                // cmds and args
                [/[a-zA-Z_][\w\-\.']*/, { cases: { '@commands': 'keyword',
                                                '@flags': 'type.keyword',
                                                '@sysflags': 'annotation',
                                                '@works': 'regexp',
                                                '@default': 'identifier' } }],

                // whitespace
                { include: '@whitespace' },

                // numbers
                [/\d*\.\d+([eE][\-+]?\d+)?/, 'number.float'],
                [/\d+/, 'number'],

                // delimiter: after number because of .\d floats
                [/[,.]/, 'delimiter'],
            ],

            whitespace: [
                [/[ \t\r\n]+/, 'white'],
                [/;.*$/,    'comment'],
            ],
        }
    });

    monaco.languages.registerHoverProvider("bdsp", {
        provideHover: function(model, position) {
            const word = model.getWordAtPosition(position);

            if (word) {
                const command = commands.find(c => c.name == word.word);
                if (command) {
                    var name = '**Command ' + command.id + ' - ' + command.name + '**';
                    var description = buildCommandDescription(command);
                    return {
                        contents: [
                            { value: name },
					        { value: description }
                        ]
                    };
                }
                const flag = flags.find(f => f.name == word.word);
                if (flag) {
                    var name = '**Flag ' + flag.id + ' - ' + flag.name + '**';
                    var description = flag.description;
                    return {
                        contents: [
                            { value: name },
					        { value: description }
                        ]
                    };
                }
                const sysflag = sysflags.find(s => s.name == word.word);
                if (sysflag) {
                    var name = '**System Flag ' + sysflag.id + ' - ' + sysflag.name + '**';
                    var description = sysflag.description;
                    return {
                        contents: [
                            { value: name },
					        { value: description }
                        ]
                    };
                }
                const work = works.find(w => w.name == word.word);
                if (work) {
                    var name = '**Work ' + work.id + ' - ' + work.name + '**';
                    var description = work.description;
                    return {
                        contents: [
                            { value: name },
					        { value: description }
                        ]
                    };
                }
            }

            // If the word is not recognized, return an empty hover
            return {
                contents: []
            };
        }
    });

    monaco.languages.registerCompletionItemProvider("bdsp", {
        provideCompletionItems: function(model, position) {
            let line = model.getLineContent(position.lineNumber);
            lineTrimmed = line.trimStart();
            let whiteSpaceLength = line.length - lineTrimmed.length;

            var word = model.getWordUntilPosition(position);
            var wordLength = word.endColumn - word.startColumn;

            // Check if the position is on the first word of a line
            if (position.column == 1 || position.column <= 1 + whiteSpaceLength + wordLength) {
		        var range = {
			        startLineNumber: position.lineNumber,
			        endLineNumber: position.lineNumber,
			        startColumn: word.startColumn,
			        endColumn: word.endColumn
		        };
                var suggestions = commands.map(c => {
                    return {
                        label: c.name,
                        kind: monaco.languages.CompletionItemKind.Function,
                        documentation: buildCommandDescription(c),
                        insertText: c.name,
                        range: range
                    }
                });
		        return {
			        suggestions: suggestions
		        };
            }
            else
            {
                var range = {
			        startLineNumber: position.lineNumber,
			        endLineNumber: position.lineNumber,
			        startColumn: word.startColumn,
			        endColumn: word.endColumn
		        };
                var suggestions = flags.map(f => {
                    return {
                        label: f.name,
                        kind: monaco.languages.CompletionItemKind.Field,
                        documentation: f.description,
                        insertText: f.name,
                        range: range
                    }
                }).concat(sysflags.map(s => {
                    return {
                        label: s.name,
                        kind: monaco.languages.CompletionItemKind.Property,
                        documentation: s.description,
                        insertText: s.name,
                        range: range
                    }
                }),
                works.map(w => {
                    return {
                        label: w.name,
                        kind: monaco.languages.CompletionItemKind.Variable,
                        documentation: w.description,
                        insertText: w.name,
                        range: range
                    }
                }));
		        return {
			        suggestions: suggestions
		        };
            }

            return {
			    suggestions: []
		    };
        }
    });
}