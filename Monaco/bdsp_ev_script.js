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
                // identifiers and keywords
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
                    var name = '**' + command.id + ' - ' + command.name + '**'
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
                    return {
                        contents: [
                            { value: name },
					        { value: description + "\n\n\n\nArguments:\n\n" + args }
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
}