
f = open('words_accented.txt', 'r')
lines = f.read().split('\n')
f.close()

words = []
for line in lines:
    fields = line.split('\t')
    try:
        words.append([fields[0], fields[1]])
        words.append(fields[2], fields[3])
    except:
        pass
    
words_processed = []
for word in words:
    foreign = word[0]
    known = word[1]
    foreign_proc = ''
    known_proc = ''
    for char in foreign:
        if char == 'é' or char == 'ë':
            foreign_proc += 'e'
        elif char == 'á' or char == 'ä':
            foreign_proc += 'a'
        elif char == 'í':
            foreign_proc += 'i'
        elif char == 'ő' or char == 'õ' or char == 'ö' or char == 'ó':
            foreign_proc += 'o'
        elif char == 'ú' or char == 'ű' or char == 'ü' or char == 'û':
            foreign_proc += 'u'
        elif char == 'ß':
            foreign_proc += 'ss'
        else:
            foreign_proc += char
    for char in known:
        if char == 'é' or char == 'ë':
            known_proc += 'e'
        elif char == 'á' or char == 'ä':
            known_proc += 'a'
        elif char == 'í':
            known_proc += 'i'
        elif char == 'ő' or char == 'õ' or char == 'ö' or char == 'ó':
            known_proc += 'o'
        elif char == 'ú' or char == 'ű' or char == 'ü' or char == 'û':
            known_proc += 'u'
        elif char == 'ß':
            known_proc += 'ss'
        else:
            known_proc += char
    words_processed.append([foreign_proc, known_proc])
    
f = open("words.txt", 'w')
for word in words_processed:
    f.write(word[0] + '\t' + word[1] + '\n')
f.close()