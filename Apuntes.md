  #  Unix Annotations
  Annotations

Supporting TOC only for website

# Table of Contents
* [Chapter 1](/chapter1/README.md)
  * [Introduction of Markdown Preview Enhanced](/chapter1/intro.md)
  * [Features](/chapter1/feature.md)
* [Chapter 2](/chapter2/README.md)
  * [Known issues](/chapter2/issues.md)
* [Chapter Some Notes about Javascript](/notes/src/javascript.md)
* [Chapter Maintaint Editor](./editor.php)


------

# :fa-commenting: Notes

* Que sí, que ya sé que el amor es ciego. Pero yo no, joder
* Social Engineering: Because there is no patch for human stupidity.
* Nobody wants to say how this works.  Maybe nobody knows ...   >> "VIDEOADAPTOR SECTION" on xorg.conf manual ファミコン
* "This is Unix-Land. In quiet nights, you can hear the Windows machines reboot"
* "Es prácticamente imposible enseñar programación correctamente a estudiantes que han estado expuestos al lenguaje BASIC con anterioridad.
  Como potenciales programadores, tienen la mente mutilada sin esperanza alguna de regeneración"
*Edsger Dijkstra*.

* No extraña que los explotadores de profesión, hayan decidido incluir en sus actividades a la media
humanidad que les faltaba, pero sorprende que algunas mujeres consideren deseable esta situación:
 además del castigo bíblico propio, quieren pasar por el que les cayó a los hombres. Y, encima, en
 modo alguno comprenden que sea un castigo, una situación nada deseable.
 Como si fueran calvinistas se portan, convencidas de que el trabajo enriquece.
 Los hombres, más entrenados, sabemos de antiguo que sólo es posible enriquecerse haciendo trabajar
a los demás.

* SOFTWARE: Es el espíritu insuflado en la dura mollera de la máquina. A veces, un clásico espíritu
burlón o poltergeist.
*Arturo Rosby*

* "«Manos a la obra, señor Freeman, manos a la obra. No quiero decir que se haya
dormido en los laureles en el trabajo. Nadie se merece más un alto en el camino y todos los
esfuerzos realizados habrí­an sido en vano hasta que... Hmmm... Bueno... Digamos que
otra vez ha llegado su hora. El hombre adecuado en el sitio equivocado puede cambiar
el rumbo del mundo. Despierte, señor Freeman. Despierte y huela las cenizas»"
*G-Man al comienzo de Half Life 2.*

* Los Grigori (del griego egrḗgoroi, que significa Observadores o vigilantes), también conocidos como
 hijos de Elohim (en hebreo בני האלהים, bnei ha'elohim);
 son un grupo de ángeles caídos de la mitología judeocristiana mencionados en algunos textos
 apócrifos Bíblicos y en el Libro del Génesis.

En estos textos se menciona que los Grigori fueron seres que se aparearon
con las "hijas del hombre" (en hebreo banot ha'adam);
naciendo de esta unión una raza de gigantes conocida como los Nephilim.

* "Si los tontos volaran, el cielo se oscurecería"

> "Recuperar alkalinidad en el cuerpo"
2 partes de agua
1 parte de jugo de limon
1 pizca de carbonato

* "Vade retro satana"
> The Latin text says:

>Crux Sancti Patris Benedicti / Cruz del Santo Padre Benito
Crux Sacra Sit Mihi Lux / Mi luz sea la cruz santa
Non Draco Sit Mihi Dux / No sea el demonio mi guía
Vade Retro Satana / ¡Apártate, Satanás!
Numquam Suade Mibi Vana / No sugieras cosas vanas
Sunt Mala Quae libas / Pues maldad es lo que brindas
Ipse Venena Bibas / Bebe tú mismo el veneno

>Crux sancta sit mihi lux / Non draco sit mihi dux
Vade retro satana / Numquam suade mihi(mibi) vana
Sunt mala quae libas / Ipse venena bibas
In approximate translation:

>Let the Holy Cross be my light / Let not the dragon be my guide
Step back Satan / Never tempt me with vain things
What you offer me is evil / You drink the poison yourself.

>La Santa Cruz sea mi luz, /no sea el dragón mi señor.
¡Apártate, Satanás! /nunca me atraigas con engaños,
maldad es tu carnada, /bebe tu propio veneno.

>INRI >> Iesus Nazarenus Rex Iudaeorum

---

どうもありがとうミスターロボット (dōmo arigatō misutā robotto)

---
My firts name
Hiragana      katakana
へすす         ヘスス
My second name
Hiragana      katakana
あるべると    アルベルト

And  my Wife's Name
  マリア・ドゥーラ

Remenber this tools on your journey

```
chntpw                NT SAM password recovery utility
ms-sys                Create DOS/MS-compatible boot records
foremost              Recover files by "carving" them from a raw
hdparm                Utility to get/set (E)IDE/SATA/SAS device parameters
ide-smart             IDE S.M.A.R.T. test and query tool
john                  Password cracker
memtester             Userspace utility to test for faulty memory subsystem
testdisk              Tool to check and undelete partition
targa                 MS Windows95/98/NT testing kit
scrounge-ntfs         Data recovery program for NTFS file systems
dmidecode             dumping bios information
galleta               An Internet Explorer cookie forensic analysis tool
pasco                 An Internet Explorer cache forensic analysis tool
lm-sensors		        check temp of your box
smartmontools		      smart-monitor
cpuburn 		          stress your cpu
			run desired program in background [ _repeat_ for SMP]:
      `burnP6 || echo $? &`
surfraw     		      example surfraw -browser=w3m google "query"
gotmail			          download e-mail from hotmail
wapua			            web browser for wap
fcrackzip		          pass-cracker
fondu			            convert between mac fonts format
encfs			            encrypt fs ?
electricsheep		      just awesone !
fatresize		
archmage 		          extract and convert chm files to html , txt or pdf
flasm			            assembler and disassembler for flash-(swf) bytecode
badblocks             for cheking bad blocks
xsw			              presentations sowftware very easy to use

```

---



# :fa-edit: Editors Section

## Improvements of Vim

* add Vundle plugin manager

``` bash
 git clone https://github.com/VundleVim/Vundle.vim.git ~/.vim/bundle/Vundle.vim
```

* Add the vimrc

``` viml
"""""""""""""""""""""""""""""""""""""
" Allan MacGregor Vimrc configuration
"""""""""""""""""""""""""""""""""""""
set encoding=utf8
"""" START Vundle Configuration
" Disable file type for vundle
filetype off                  " required

" set the runtime path to include Vundle and initialize
set rtp+=~/.vim/bundle/Vundle.vim
call vundle#begin()

" let Vundle manage Vundle, required
Plugin 'gmarik/Vundle.vim'

```

<div style="page-break-after: always;"></div>

``` viml

" Utility
Plugin 'scrooloose/nerdtree'
Plugin 'majutsushi/tagbar'
Plugin 'ervandew/supertab'
Plugin 'BufOnly.vim'
Plugin 'wesQ3/vim-windowswap'
Plugin 'SirVer/ultisnips'
Plugin 'junegunn/fzf.vim'
Plugin 'junegunn/fzf'
Plugin 'godlygeek/tabular'
Plugin 'ctrlpvim/ctrlp.vim'
Plugin 'benmills/vimux'
Plugin 'jeetsukumaran/vim-buffergator'
Plugin 'gilsondev/searchtasks.vim'
Plugin 'Shougo/neocomplete.vim'
Plugin 'tpope/vim-dispatch'

" Generic Programming Support
Plugin 'jakedouglas/exuberant-ctags'
Plugin 'honza/vim-snippets'
Plugin 'Townk/vim-autoclose'
Plugin 'tomtom/tcomment_vim'
Plugin 'tobyS/vmustache'
Plugin 'janko-m/vim-test'
Plugin 'maksimr/vim-jsbeautify'
Plugin 'vim-syntastic/syntastic'
Plugin 'neomake/neomake'

" Markdown / Writting
Plugin 'reedes/vim-pencil'
Plugin 'tpope/vim-markdown'
Plugin 'jtratner/vim-flavored-markdown'
Plugin 'LanguageTool'

" Git Support
Plugin 'kablamo/vim-git-log'
Plugin 'gregsexton/gitv'
Plugin 'tpope/vim-fugitive'
"Plugin 'jaxbot/github-issues.vim'

" PHP Support
Plugin 'phpvim/phpcd.vim'
Plugin 'tobyS/pdv'

" Erlang Support
Plugin 'vim-erlang/vim-erlang-tags'
Plugin 'vim-erlang/vim-erlang-runtime'
Plugin 'vim-erlang/vim-erlang-omnicomplete'
Plugin 'vim-erlang/vim-erlang-compiler'

" Elixir Support
Plugin 'elixir-lang/vim-elixir'
Plugin 'avdgaag/vim-phoenix'
Plugin 'mmorearty/elixir-ctags'
Plugin 'mattreduce/vim-mix'
Plugin 'BjRo/vim-extest'
Plugin 'frost/vim-eh-docs'
Plugin 'slashmili/alchemist.vim'
Plugin 'tpope/vim-endwise'
Plugin 'jadercorrea/elixir_generator.vim'

```

<div style="page-break-after: always;"></div>

``` viml

" Elm Support
Plugin 'lambdatoast/elm.vim'

" Theme / Interface
Plugin 'AnsiEsc.vim'
Plugin 'ryanoasis/vim-devicons'
Plugin 'vim-airline/vim-airline'
Plugin 'vim-airline/vim-airline-themes'
Plugin 'sjl/badwolf'
Plugin 'tomasr/molokai'
Plugin 'morhetz/gruvbox'
Plugin 'zenorocha/dracula-theme', {'rtp': 'vim/'}
Plugin 'junegunn/limelight.vim'
Plugin 'mkarmona/colorsbox'
Plugin 'romainl/Apprentice'
Plugin 'Lokaltog/vim-distinguished'
Plugin 'chriskempson/base16-vim'
Plugin 'w0ng/vim-hybrid'
Plugin 'AlessandroYorba/Sierra'
Plugin 'daylerees/colour-schemes'
Plugin 'effkay/argonaut.vim'
Plugin 'ajh17/Spacegray.vim'
Plugin 'atelierbram/Base2Tone-vim'
Plugin 'colepeters/spacemacs-theme.vim'

call vundle#end()            " required
filetype plugin indent on    " required
"""" END Vundle Configuration

"""""""""""""""""""""""""""""""""""""
" Configuration Section
"""""""""""""""""""""""""""""""""""""
set nowrap

" OSX stupid backspace fix
set backspace=indent,eol,start

" Show linenumbers
set number

" Set Proper Tabs
set tabstop=4
set shiftwidth=4
set smarttab
set expandtab

" Always display the status line
set laststatus=2

" Enable Elite mode, No ARRRROWWS!!!!
let g:elite_mode=1

" Enable highlighting of the current line
set cursorline

" Theme and Styling
syntax on
set t_Co=256

```

<div style="page-break-after: always;"></div>

``` viml

" if (has("termguicolors"))
"   set termguicolors
" endif

let base16colorspace=256  " Access colors present in 256 colorspace
colorscheme spacegray

let g:spacegray_underline_search = 1
let g:spacegray_italicize_comments = 1

" Vim-Airline Configuration
let g:airline#extensions#tabline#enabled = 1
let g:airline_powerline_fonts = 1
let g:airline_theme='hybrid'
let g:hybrid_custom_term_colors = 1
let g:hybrid_reduced_contrast = 1

" Syntastic Configuration
set statusline+=%#warningmsg#
set statusline+=%{SyntasticStatuslineFlag()}
set statusline+=%*

let g:syntastic_always_populate_loc_list = 1
let g:syntastic_auto_loc_list = 1
let g:syntastic_check_on_open = 1
" let g:syntastic_check_on_wq = 0
" let g:syntastic_enable_elixir_checker = 1
" let g:syntastic_elixir_checkers = ["elixir"]

" Neomake settings
autocmd! BufWritePost * Neomake
let g:neomake_elixir_enabled_makers = ['mix', 'credo', 'dogma']

" Vim-PDV Configuration
let g:pdv_template_dir = $HOME ."/.vim/bundle/pdv/templates_snip"

" Markdown Syntax Support
augroup markdown
    au!
    au BufNewFile,BufRead *.md,*.markdown setlocal filetype=ghmarkdown
augroup END

" Vim-Alchemist Configuration
let g:alchemist#elixir_erlang_src = "/Users/amacgregor/Projects/Github/alchemist-source"
let g:alchemist_tag_disable = 1

" Vim-Supertab Configuration
let g:SuperTabDefaultCompletionType = "<C-X><C-O>"

" Settings for Writting
let g:pencil#wrapModeDefault = 'soft'   " default is 'hard'
let g:languagetool_jar  = '/opt/languagetool/languagetool-commandline.jar'

" Vim-pencil Configuration
augroup pencil
  autocmd!
  autocmd FileType markdown,mkd call pencil#init()
  autocmd FileType text         call pencil#init()
augroup END

```

<div style="page-break-after: always;"></div>

``` viml

" Vim-UtilSnips Configuration
" Trigger configuration. Do not use <tab> if you use https://github.com/Valloric/YouCompleteMe.
let g:UltiSnipsUsePythonVersion = 3
let g:UltiSnipsExpandTrigger="<tab>"
let g:UltiSnipsJumpForwardTrigger="<c-b>"
let g:UltiSnipsJumpBackwardTrigger="<c-z>"
let g:UltiSnipsEditSplit="vertical" " If you want :UltiSnipsEdit to split your window.

" Vim-Test Configuration
let test#strategy = "vimux"

" Neocomplete Settings
let g:acp_enableAtStartup = 0
let g:neocomplete#enable_at_startup = 1
let g:neocomplete#enable_smart_case = 1
let g:neocomplete#sources#syntax#min_keyword_length = 3

" Define dictionary.
let g:neocomplete#sources#dictionary#dictionaries = {
    \ 'default' : '',
    \ 'vimshell' : $HOME.'/.vimshell_hist',
    \ 'scheme' : $HOME.'/.gosh_completions'
        \ }

" Define keyword.
if !exists('g:neocomplete#keyword_patterns')
    let g:neocomplete#keyword_patterns = {}
endif
let g:neocomplete#keyword_patterns['default'] = '\h\w*'

function! s:my_cr_function()
  return (pumvisible() ? "\<C-y>" : "" ) . "\<CR>"
  " For no inserting <CR> key.
  "return pumvisible() ? "\<C-y>" : "\<CR>"
endfunction

" Close popup by <Space>.
"inoremap <expr><Space> pumvisible() ? "\<C-y>" : "\<Space>"

" AutoComplPop like behavior.
"let g:neocomplete#enable_auto_select = 1


" Enable omni completion.
autocmd FileType css setlocal omnifunc=csscomplete#CompleteCSS
autocmd FileType html,markdown setlocal omnifunc=htmlcomplete#CompleteTags
autocmd FileType javascript setlocal omnifunc=javascriptcomplete#CompleteJS
autocmd FileType python setlocal omnifunc=pythoncomplete#Complete
autocmd FileType xml setlocal omnifunc=xmlcomplete#CompleteTags

" Enable heavy omni completion.
if !exists('g:neocomplete#sources#omni#input_patterns')
  let g:neocomplete#sources#omni#input_patterns = {}
endif
"let g:neocomplete#sources#omni#input_patterns.php = '[^. \t]->\h\w*\|\h\w*::'
"let g:neocomplete#sources#omni#input_patterns.c = '[^.[:digit:] *\t]\%(\.\|->\)'
"let g:neocomplete#sources#omni#input_patterns.cpp = '[^.[:digit:] *\t]\%(\.\|->\)\|\h\w*::'

" For perlomni.vim setting.
" https://github.com/c9s/perlomni.vim
let g:neocomplete#sources#omni#input_patterns.perl = '\h\w*->\h\w*\|\h\w*::'

```

<div style="page-break-after: always;"></div>

``` viml

" Elixir Tagbar Configuration
let g:tagbar_type_elixir = {
    \ 'ctagstype' : 'elixir',
    \ 'kinds' : [
        \ 'f:functions',
        \ 'functions:functions',
        \ 'c:callbacks',
        \ 'd:delegates',
        \ 'e:exceptions',
        \ 'i:implementations',
        \ 'a:macros',
        \ 'o:operators',
        \ 'm:modules',
        \ 'p:protocols',
        \ 'r:records',
        \ 't:tests'
    \ ]
    \ }

" Fzf Configuration
" This is the default extra key bindings
let g:fzf_action = {
  \ 'ctrl-t': 'tab split',
  \ 'ctrl-x': 'split',
  \ 'ctrl-v': 'vsplit' }

" Default fzf layout
" - down / up / left / right
let g:fzf_layout = { 'down': '~40%' }

" In Neovim, you can set up fzf window using a Vim command
let g:fzf_layout = { 'window': 'enew' }
let g:fzf_layout = { 'window': '-tabnew' }

" Customize fzf colors to match your color scheme
let g:fzf_colors =
\ { 'fg':      ['fg', 'Normal'],
  \ 'bg':      ['bg', 'Normal'],
  \ 'hl':      ['fg', 'Comment'],
  \ 'fg+':     ['fg', 'CursorLine', 'CursorColumn', 'Normal'],
  \ 'bg+':     ['bg', 'CursorLine', 'CursorColumn'],
  \ 'hl+':     ['fg', 'Statement'],
  \ 'info':    ['fg', 'PreProc'],
  \ 'prompt':  ['fg', 'Conditional'],
  \ 'pointer': ['fg', 'Exception'],
  \ 'marker':  ['fg', 'Keyword'],
  \ 'spinner': ['fg', 'Label'],
  \ 'header':  ['fg', 'Comment'] }

" Enable per-command history.
" CTRL-N and CTRL-P will be automatically bound to next-history and
" previous-history instead of down and up. If you don't like the change,
" explicitly bind the keys to down and up in your $FZF_DEFAULT_OPTS.
let g:fzf_history_dir = '~/.local/share/fzf-history'

"""""""""""""""""""""""""""""""""""""
" Mappings configurationn
"""""""""""""""""""""""""""""""""""""
map <C-n> :NERDTreeToggle<CR>
map <C-m> :TagbarToggle<CR>

```

<div style="page-break-after: always;"></div>

``` viml

" Omnicomplete Better Nav
inoremap <expr> <c-j> ("\<C-n>")
inoremap <expr> <c-k> ("\<C-p>")

" Neocomplete Plugin mappins
inoremap <expr><C-g>     neocomplete#undo_completion()
inoremap <expr><C-l>     neocomplete#complete_common_string()

" Recommended key-mappings.
" <CR>: close popup and save indent.
inoremap <silent> <CR> <C-r>=<SID>my_cr_function()<CR>

" <TAB>: completion.
inoremap <expr><TAB>  pumvisible() ? "\<C-n>" : "\<TAB>"

" <C-h>, <BS>: close popup and delete backword char.
inoremap <expr><C-h> neocomplete#smart_close_popup()."\<C-h>"
inoremap <expr><BS> neocomplete#smart_close_popup()."\<C-h>"

" Mapping selecting Mappings
nmap <leader><tab> <plug>(fzf-maps-n)
xmap <leader><tab> <plug>(fzf-maps-x)
omap <leader><tab> <plug>(fzf-maps-o)

" Shortcuts
nnoremap <Leader>o :Files<CR>
nnoremap <Leader>O :CtrlP<CR>
nnoremap <Leader>w :w<CR>

" Insert mode completion
imap <c-x><c-k> <plug>(fzf-complete-word)
imap <c-x><c-f> <plug>(fzf-complete-path)
imap <c-x><c-j> <plug>(fzf-complete-file-ag)
imap <c-x><c-l> <plug>(fzf-complete-line)

" Vim-Test Mappings
nmap <silent> <leader>t :TestNearest<CR>
nmap <silent> <leader>T :TestFile<CR>
nmap <silent> <leader>a :TestSuite<CR>
nmap <silent> <leader>l :TestLast<CR>
nmap <silent> <leader>g :TestVisit<CR>

" Vim-PDV Mappings
autocmd FileType php inoremap <C-p> <ESC>:call pdv#DocumentWithSnip()<CR>i
autocmd FileType php nnoremap <C-p> :call pdv#DocumentWithSnip()<CR>
autocmd FileType php setlocal omnifunc=phpcd#CompletePHP

" Disable arrow movement, resize splits instead.
"if get(g:, 'elite_mode')
"	nnoremap <Up>    :resize +2<CR>
"	nnoremap <Down>  :resize -2<CR>
"	nnoremap <Left>  :vertical resize +2<CR>
"	nnoremap <Right> :vertical resize -2<CR>
"endif

map <silent> <LocalLeader>ws :highlight clear ExtraWhitespace<CR>

```

<div style="page-break-after: always;"></div>

``` viml

" Advanced customization using autoload functions
inoremap <expr> <c-x><c-k> fzf#vim#complete#word({'left': '15%'})

" Vim-Alchemist Mappings
autocmd FileType elixir nnoremap <buffer> <leader>h :call alchemist#exdoc()<CR>
autocmd FileType elixir nnoremap <buffer> <leader>d :call alchemist#exdef()<CR>
```

* then inside vim type:

``` viml
run :PluginInstall "OR " :BundleInstall
```

> OR To install from command line:


```bash
  vim +PluginInstall +qall
```

more details in https://github.com/VundleVim/Vundle.vim

Some package issues *UltiSnips* adding this option to your .vimrc: for force the version

``` viml
let g:UltiSnipsUsePythonVersion = 2
```
maybe you need install python support in vim

``` bash
sudo apt-get install vim-python-jedi
```

YouCompleteMe code appended randomly when moving around with arrow keys in insert mode

```viml
pumvisible() ? "\pumvisible" : "\
```

This occurs often but randomly and it will persist for the entirety of the session. Loading or creating a different file will not fix the issue. It only goes away if neovim is relaunched.
Just as a reference to anyone who comes across this with the same issue,  I found that the plugin "Townk/vim-autoclose" was causing the conflict. This plugin is old and hasn't been updated in a while and causes quite a few other conflicts.
I removed it and used "Raimondi/delimitMate" instead.


```bash
# check if vim has python
vim --version | grep --color python
```

#### Save doc as root with vim

Update ~/.vimrc file

Open/Edit ~/.vimrc file and append the following code:

```viml
command W :execute ':silent w !sudo tee % > /dev/null' | :edit!
"OR"
" Allow saving of files as sudo when I forgot to start vim using sudo.
cmap w!! w !sudo tee > /dev/null %

```


* then are you done

#### vim code

##### Deleting form feed ^L characters

```vimrl
  :%s/^L//g
```

  will do it. Enter the ^L using ctrl-V ctrl-L

Command

:%s/<Ctrl-V><Ctrl-M>/\r/g
Where <Ctrl-V><Ctrl-M> means type Ctrl+V then Ctrl+M.
Explanation
:%s
substitute, % = all lines
<Ctrl-V><Ctrl-M>
^M characters (the Ctrl-V is a Vim way of writing the Ctrl ^ character and Ctrl-M writes the M after the regular expression, resulting to ^M special character)
/\r/
with new line (\r)
g
And do it globally (not just the first occurrence on the line).


# :fa-music: Audio Section

## Audio Recording and Encoding in Linux
> src : http://mocha.freeshell.org/audio.html

Linux is a professional class operating system, so if you plan to do audio
recording and encoding then you chose the proper system.

I use Pulseaudio on some boxes and just Alsa on other boxes.  As of this
writing (Summer 2011) Pulseaudio has all the major bugs worked out, so all the
old web discussions about it causing issues are no longer relevant as far as
I'm concerned.

When using Pulseaudio you are strongly advised to install the GUI management
tools in order to control the audio streams and volumes and so forth.  You can
do it at the command line which is great, but it is a bit cumbersome unless
you are using a recording script (which I will demonstrate later).

If only using Alsa, then there is usually an added step of specifying the
audio device in the recording command.  For example, arecord expects a "-D
plughw:0,0" or "-D hw:0,0".  You also need to use the alsamixer utility to
control the selection of external sources and gain levels.  Actually, gurus
will also use alsamixer on Pulseaudio systems as well when recording from
sources such as line-in or microphones.

arecord examples
ffmpeg examples
speex format
voice activated recording
useful scripts


* * *

### Examples of recording and piping the output to a compressed format:
``` bash
arecord -v -f cd -t raw | lame -r - output.mp3

arecord -v -f cd -t raw | lame -r -b 192 - output.mp3

arecord -v -f cd -t raw | lame -r -m s -a -b 64 - output.mp3

arecord -v -f cd -t raw | lame -r -h -V 0 -b 128 -B 224 - output.mp3

arecord -v -f cd -t raw | lame -r --preset extreme - output.mp3

arecord -vv -f cd output.wav

arecord -f dat output.wav

arecord -f S16_LE -c1 -r22050 -t raw | lame -r -s 22.05 -m m -b 64 -
Output.mp3

arecord -f S16_LE -c1 -r22050 -t raw | oggenc - -r -C 1 -R 22050 -q 2 -o
Output.ogg

arecord -f S16_LE -c1 -r22050 -t raw -d xxxx | oggenc-aotuvb5d - -r -C 1 -R
22050 -o Output.ogg

```

(-d xxxx limits the recording time in seconds, useful for scripts)
(oggenc -q option is -1 to 10 where higher numbers mean higher
quality/bitrate, the default is 3)

It's probably a good idea to read the man pages of arecord, lame, and oggenc
(the aotuv version is just an enhanced version).  Basically the "-f" in
arecord allows you to select a pre-packaged format like CD (44.1 kHz, 16 bits
little endian, 2 channels) or DAT (48 kHz, 16 bits little endian, 2 channels),
or you can get specific and choose S16_LE (16 bit little endian) -c1 (mono)
-r22050 (22.050 kHz sampling rate), and so forth.

What you pipe arecord out to needs to logically match how you are recording
with arecord.  Notice that when I record in "CD" or "DAT" formats I choose
high quality options in lame.  When I use lower quality options in arecord, I
also use lower encoding demand parameters in lame and oggenc.

Digital audio recording is all about specifying a quantizing method, sample
rate, number of channels, bits per channel, and compression schemes and
bitrates.  Read the man pages.

* * *

### Using ffmpeg to record and encode:

```bash
#!/bin/bash

ffmpeg -f alsa -ac 2 -ar 44100 -ab 160k -i pulse -acodec libvorbis
OUTPUT.ogg

ffmpeg -f alsa -ac 2 -ar 44100 -ab 160k -i pulse -acodec libmp3lame
OUTPUT.mp3

ffmpeg -f alsa -ac 2 -ar 44100 -i pulse OUTPUT.flac

```

The placement of "-i pulse" and "-acodec xxx" is critical in order for ffmpeg
to encode in 2 channels, if -i pulse was at the beginning of the command line
it would only see mono audio.  Use the Pulseaudio tools to select the audio
source to record, or use the option to specify an audio device (-i hw:0,0) if
using Alsa only.

* * *

### Some record/encode examples with the Speex format:

Example of transcoding an MP3 to 16 kHz speex:
```bash
sox INPUT.MP3 -t wav -r 16000 - | speexenc - --denoise OUTPUT.SPX

```
Example encoding of wav file.  Speex prefers input file sampling rates of 8 or
16 kHz:

```bash

speexenc --vbr --denoise INPUT.WAV OUTPUT.SPX
```

Piping arecord to speexenc (realtime speex encoding method):

```bash
$ arecord -f S16_LE -c1 -r8000 -t raw | speexenc - --vad OUTPUT.SPX
```

* * *

### Sound Activated Recording, VOX recording, Sound Operated Recording:

This stuff goes by many names.  Basically, it describes a method to only
record incoming audio signals that meet or exceed a user-specified threshold
level.  It's useful when recording from police scanner radios or microphones
that are setup to record intermittent audio.

On Winblows there are numerous programs to accomplish this.  On Linux there
are only two methods that I've discovered that work properly.

[Audacity](http://audacity.sourceforge.net/).  Audacity now has an option
under the Transport menu to do "Sound Activated Recording" and allows you to
set an input threshold dB level.  It appears to be stable, I've set it up to
record from my motherboard's line-in for up to 20 hour periods with no crashes
or memory leaks.

[VACR](http://git.wizzup.org/vacr.git/).  This is a python script that works
well from the command line.  It has limted options but the default threshold
detection method works very well.  There are a few places in the script to
specify the sample rate and output file name.  There is also a line to tweak
the threshold level gate.

Update 11/23/11.  I found the script below on a German language forum.  This
method uses sox (major points for that) and works very well.  The big
advantages of this script is that sox lets you encode how you want (fine grain
control), and you can also do post-processing, in this case the creator had a
normalizing section and also generated a nice spectra energy graph.  I've been
using this script in some form or another for about a month now.

``` bash

#!/bin/bash
#source http://www.sis-germany.de/index.php?page=Thread&amp;threadID=1444

NAME=`date +%m-%d-%Y_%H-%M-%S`

#choose a method below, either the decibel or % of level method
#also choose number of channels, sample rate, encoding, etc..
#you need to find a level that works for your hardware

#rec -c 1 -r 22050 $NAME.wav silence 1 0 -22d -1 00:00:05 -22d
#rec -c 1 -r 22050 $NAME.wav silence 1 0 8% -1 00:00:05 8%
rec -c 1 -r 22050 $NAME.mp3 silence 1 0 8% -1 00:00:05 8%
#rec -c 1 -r 22050 $NAME.mp3 silence 1 0 25% -1 00:00:05 25%

#uncomment appropriate line below for normalizing when finished

#echo "Normalize..."
#sox $NAME.wav $NAME-norm.wav gain -n -1
#sox $NAME.mp3 $NAME-norm.mp3 gain -n -1

#uncomment appropriate line below for a spectral graph if desired

#echo "Calculating Spectrogram..."
#sox $NAME.wav -n spectrogram -x 1024 -y 768 -z 100 -t "$NAME.wav" -c '' -o
$NAME.png
#sox $NAME.mp3 -n spectrogram -x 1024 -y 768 -z 100 -t "$NAME.mp3" -c '' -o
$NAME.png
#echo "Done."
```

```bash
for f in *.ogg; do sox "$f" "${f%.ogg}.mp3"; done
```
---

### Script methods:

Here is a script to record from the Pulseaudio monitor source.  The monitor
source is basically the source that you hear the audio coming from out of your
speakers.

```bash
#!/bin/bash
# Records the PulseAudio monitor channel.
# Uncomment the wav or mp3 output extension for OUTFILE then specify if a
# particular bitrate is needed for mp3

if [ -n "$1" ]; then
`OUTFILE="$1"
else
  `IME=$(date +%d-%b-%y_%H%M-%Z)
  #Choose wav or mp3 output
  #OUTFILE="recording_$TIME.wav"
  OUTFILE="recording_$TIME.mp3"
fi

# Get sink monitor:
MONITOR=$(pactl list | grep -A2 '^Source #' | grep "Name: .*\\.monitor$" | awk'{print $NF}' | tail -n1);
# Record it raw, and convert to a wav, uncomment the method you need below.
echo "Recording. Ctrl-C or close window to stop";
#44.1 kHz, 16 bit little endian, 2 channels, line below is the deprecated method
#parec -d "$MONITOR" | sox -t raw -r 44100 -sLb 16 -c 2 - "$OUTFILE"
#Defaults to 128 kbps when encoding directly to mp3
#parec -d "$MONITOR" | sox -t raw -r 44100 -b 16 -L -e signed -c 2 - "$OUTFILE"
#-C192 uses 192 kbps when encoding directly to mp3
parec -d "$MONITOR" | sox -t raw -r 44100 -b 16 -L -e signed -c 2 - -C192 "$OUTFILE"

```

-----------------------------------------------------------------------

Here is an example script that grabs an Internet stream and converts it to
ogg.  This is a useful script for a cron job.

```bash
#!/bin/bash
# set up the variables below as needed, they're self explanitory
DATE1=$(date +"%d%m%Y")
DATE2=$(date +"%d-%m-%Y")
STREAM=http://www.123.com/xxxxx.ram
DURATION=2.2h
MUSIC_DIR=$HOME/temp

cd $MUSIC_DIR
# Download the stream and convert it to wave format:
mplayer -cache 2048 -playlist $STREAM \
        -vc null -vo null -ao pcm:fast:waveheader:file=output.wav &amp;

sleep $DURATION # Length of the program being recorded as background.
kill $!         # End the most recently backgrounded job = mplayer

# Convert to ogg format and place the appropriate tags:

oggenc -q 6 output.wav \
         -t "title string: $DATE2" \
         -l "album string" \
         -a "artist string" \
         -o output_$DATE1.ogg
rm output.wav
```
------------------------------------------------------------------------

#### Pulse Audio Equalizer

Load equalizer sink and dbus-protocol module

$ pactl load-module module-equalizer-sink
$ pactl load-module module-dbus-protocol

GUI front-end

run:

$ qpaeq

Note: If qpaeq has no effect, install pavucontrol and change "ALSA Playback on" to "FFT based equalizer on ..." while the media player is running.
Load equalizer and dbus module on every boot

Edit the /etc/pulse/default.pa or ~/.config/pulse/default.pa file with your favorite editor and append the following lines:

### Load the integrated PulseAudio equalizer and D-Bus module
load-module module-equalizer-sink
load-module module-dbus-protocol

Note: The equalizer sink needs to be loaded after the master sink is already available.



# :fa-server: Server Section

### Virtual Servers in Apache

### Introduction

The Apache web server is the most popular way of serving web content on the internet. It accounts for more than half of all active websites on the internet and is extremely powerful and flexible.

#### Setting the rules

First, useradd creates a new user. As you (iain) already exist, you want to call usermod instead. So that would be:

```bash
sudo usermod -aG www-data ambagasdowa
addgroup www-data
```

(note the -a on Debian-based servers (Ubuntu included) that will add you to that group, and keep your membership to other groups.
Forget it and you will belong to the www-data group only - could be a bad experience if one of them was wheel.
On SUSE-type servers the option is -A instead of -aG so read man usermod carefully to get it right.)

Second, you don't want apache to have full rw access to /var/www: this is potentially a major security breach.
As a general rule, allow only what you need, and nothing more (principle of least privilege).
In this case, you need apache (www-data) and you (www-data group) to write (and read) in /var/www/example.com/public_html,
so

```bash
sudo chown -R www-data:www-data /var/www/example.com/public_html
sudo chmod -R 770 /var/www/example.com/public_html
```

Edit: to answer your original question, yes, any member of www-data can now read and execute /var/www
(because the last bit of your permissions is 5 = read + exec).
But because you haven't used the -R switch, that applies only to /var/www,
 and not to the files and sub-directories it contains. Now, whether they can write is another matter,
  and depends on the group of /var/www, which you haven't set. I guess it is typically root:root, so no,
  they (probably) can't write.

Edit on 2014-06-22: added a note that -aG option is valid on Debian-based servers.
 It apparently varies with the distribution, so read man carefully before executing.


##### Step One — Create the Directory Structure

The first step that we are going to take is to make a directory structure that will hold the site data that we will be serving to visitors.

Our document root (the top-level directory that Apache looks at to find content to serve) will be set to individual directories under the /var/www directory. We will create a directory here for both of the virtual hosts we plan on making.

Within each of these directories, we will create a public_html folder that will hold our actual files. This gives us some flexibility in our hosting.

For instance, for our sites, we're going to make our directories like this:

```bash
sudo mkdir -p /var/www/example.com/public_html
sudo mkdir -p /var/www/test.com/public_html
```

The portions in red represent the domain names that we are wanting to serve from our VPS.

##### Step Two — Grant Permissions

Now we have the directory structure for our files, but they are owned by our root user. If we want our regular user to be able to modify files in our web directories, we can change the ownership by doing this:

```bash
sudo chown -R $USER:$USER /var/www/example.com/public_html
sudo chown -R $USER:$USER /var/www/test.com/public_html
```

The ``` $USER ``` variable will take the value of the user you are currently logged in as when you press "ENTER". By doing this, our regular user now owns the public_html subdirectories where we will be storing our content.

We should also modify our permissions a little bit to ensure that read access is permitted to the general web directory and all of the files and folders it contains so that pages can be served correctly:

```bash
sudo chmod -R 755 /var/www
```

Your web server should now have the permissions it needs to serve content, and your user should be able to create content within the necessary folders.

##### Step Three — Create Demo Pages for Each Virtual Host

We have our directory structure in place. Let's create some content to serve.

We're just going for a demonstration, so our pages will be very simple. We're just going to make an index.html page for each site.

Let's start with example.com. We can open up an index.html file in our editor by typing:

```bash
nano /var/www/example.com/public_html/index.html
```

In this file, create a simple HTML document that indicates the site it is connected to. My file looks like this:

``` html
<html>
  <head>
    <title>Welcome to Example.com!</title>
  </head>
  <body>
    <h1>Success!  The example.com virtual host is working!</h1>
  </body>
</html>
```

Save and close the file when you are finished.

We can copy this file to use as the basis for our second site by typing:

```bash
cp /var/www/example.com/public_html/index.html /var/www/test.com/public_html/index.html
```

We can then open the file and modify the relevant pieces of information:

```bash
nano /var/www/test.com/public_html/index.html
```

```html
<html>
  <head>
    <title>Welcome to Test.com!</title>
  </head>
  <body>
    <h1>Success!  The test.com virtual host is working!</h1>
  </body>
</html>
```

Save and close this file as well. You now have the pages necessary to test the virtual host configuration.

##### Step Four — Create New Virtual Host Files

Virtual host files are the files that specify the actual configuration of our virtual hosts and dictate how the Apache web server will respond to various domain requests.

Apache comes with a default virtual host file called 000-default.conf that we can use as a jumping off point. We are going to copy it over to create a virtual host file for each of our domains.

We will start with one domain, configure it, copy it for our second domain, and then make the few further adjustments needed. The default Ubuntu configuration requires that each virtual host file end in .conf.

##### Create the First Virtual Host File

Start by copying the file for the first domain:

```bash
sudo cp /etc/apache2/sites-available/000-default.conf /etc/apache2/sites-available/example.com.conf
```

Open the new file in your editor with root privileges:

```bash
sudo nano /etc/apache2/sites-available/example.com.conf
```

The file will look something like this (I've removed the comments here to make the file more approachable):

``` xml
<VirtualHost *:80>
    ServerAdmin webmaster@localhost
    DocumentRoot /var/www/html
    ErrorLog ${APACHE_LOG_DIR}/error.log
    CustomLog ${APACHE_LOG_DIR}/access.log combined
</VirtualHost>
```

As you can see, there's not much here. We will customize the items here for our first domain and add some additional directives. This virtual host section matches any requests that are made on port 80, the default HTTP port.

First, we need to change the ServerAdmin directive to an email that the site administrator can receive emails through.

ServerAdmin admin@example.com

After this, we need to add two directives. The first, called ServerName, establishes the base domain that should match for this virtual host definition. This will most likely be your domain. The second, called ServerAlias, defines further names that should match as if they were the base name. This is useful for matching hosts you defined, like www:

      ServerName example.com
      ServerAlias www.example.com

The only other thing we need to change for a basic virtual host file is the location of the document root for this domain. We already created the directory we need, so we just need to alter the DocumentRoot directive to reflect the directory we created:

      DocumentRoot /var/www/example.com/public_html

In total, our virtualhost file should look like this:

``` xml
<VirtualHost *:80>
    ServerAdmin admin@example.com
    ServerName example.com
    ServerAlias www.example.com
    DocumentRoot /var/www/example.com/public_html
    ErrorLog ${APACHE_LOG_DIR}/error.log
    CustomLog ${APACHE_LOG_DIR}/access.log combined
</VirtualHost>
```

Save and close the file.

Copy First Virtual Host and Customize for Second Domain

Now that we have our first virtual host file established, we can create our second one by copying that file and adjusting it as needed.

Start by copying it:

``` bash
sudo cp /etc/apache2/sites-available/example.com.conf /etc/apache2/sites-available/test.com.conf
```

Open the new file with root privileges in your editor:

sudo nano /etc/apache2/sites-available/test.com.conf
You now need to modify all of the pieces of information to reference your second domain. When you are finished, it may look something like this:

``` xml
<VirtualHost *:80>
    ServerAdmin admin@test.com
    ServerName test.com
    ServerAlias www.test.com
    DocumentRoot /var/www/test.com/public_html
    ErrorLog ${APACHE_LOG_DIR}/error.log
    CustomLog ${APACHE_LOG_DIR}/access.log combined
</VirtualHost>
```

Save and close the file when you are finished.

Step Five — Enable the New Virtual Host Files
Now that we have created our virtual host files, we must enable them. Apache includes some tools that allow us to do this.

We can use the a2ensite tool to enable each of our sites like this:

sudo a2ensite example.com.conf
sudo a2ensite test.com.conf
When you are finished, you need to restart Apache to make these changes take effect:

sudo service apache2 restart
You will most likely receive a message saying something similar to:

 * Restarting web server apache2
 AH00558: apache2: Could not reliably determine the server's fully qualified domain name, using 127.0.0.1. Set the 'ServerName' directive globally to suppress this message
This is a harmless message that does not affect our site.

Step Six — Set Up Local Hosts File (Optional)
If you haven't been using actual domain names that you own to test this procedure and have been using some example domains instead, you can at least test the functionality of this process by temporarily modifying the hosts file on your local computer.

This will intercept any requests for the domains that you configured and point them to your VPS server, just as the DNS system would do if you were using registered domains. This will only work from your computer though, and is simply useful for testing purposes.

Make sure you are operating on your local computer for these steps and not your VPS server. You will need to know the computer's administrative password or otherwise be a member of the administrative group.

If you are on a Mac or Linux computer, edit your local file with administrative privileges by typing:

sudo nano /etc/hosts
If you are on a Windows machine, you can find instructions on altering your hosts file here.

The details that you need to add are the public IP address of your VPS server followed by the domain you want to use to reach that VPS.

For the domains that I used in this guide, assuming that my VPS IP address is 111.111.111.111, I could add the following lines to the bottom of my hosts file:

127.0.0.1   localhost
127.0.1.1   guest-desktop
111.111.111.111 example.com
111.111.111.111 test.com
This will direct any requests for example.com and test.com on our computer and send them to our server at 111.111.111.111. This is what we want if we are not actually the owners of these domains in order to test our virtual hosts.

Save and close the file.

Step Seven — Test your Results
Now that you have your virtual hosts configured, you can test your setup easily by going to the domains that you configured in your web browser:

http://example.com
You should see a page that looks like this:

Apache virt host example

Likewise, if you can visit your second page:

http://test.com
You will see the file you created for your second site:

Apache virt host test

If both of these sites work well, you've successfully configured two virtual hosts on the same server.

If you adjusted your home computer's hosts file, you may want to delete the lines you added now that you verified that your configuration works. This will prevent your hosts file from being filled with entries that are not actually necessary.

If you need to access this long term, consider purchasing a domain name for each site you need and setting it up to point to your VPS server.

Conclusion
If you followed along, you should now have a single server handling two separate domain names. You can expand this process by following the steps we outlined above to make additional virtual hosts.

There is no software limit on the number of domain names Apache can handle, so feel free to make as many as your server is capable of handling.

#### User www-data
 if we need run some command as www-data user then

```bash
  sudo -u www-data bash-command
```

### Improvement in Nginx Server

##### How To Set Up Nginx Server Blocks (Virtual Hosts) on Debian


When using the Nginx web server, server blocks (similar to the virtual hosts in Apache) can be used to encapsulate configuration details and host more than one domain off of a single server.

In this guide, we'll discuss how to configure server blocks in Nginx on an Ubuntu 16.04 server.

> Prerequisites
We're going to be using a non-root user with sudo privileges throughout this tutorial. If you do not have a user like this configured, you can create one by following our Ubuntu 16.04 initial server setup guide.

You will also need to have Nginx installed on your server. The following guides cover this procedure:

How To Install Nginx on Ubuntu 16.04: Use this guide to set up Nginx on its own.
How To Install Linux, Nginx, MySQL, PHP (LEMP stack) in Ubuntu 16.04: Use this guide if you will be using Nginx in conjunction with MySQL and PHP.
When you have fulfilled these requirements, you can continue on with this guide.

Example Configuration
For demonstration purposes, we're going to set up two domains with our Nginx server. The domain names we'll use in this guide are example.com and test.com.

You can find a guide on how to set up domain names with DigitalOcean here. If you do not have two spare domain names to play with, use dummy names for now and we'll show you later how to configure your local computer to test your configuration.

Step One: Set Up New Document Root Directories
By default, Nginx on Ubuntu 16.04 has one server block enabled by default. It is configured to serve documents out of a directory at /var/www/html.

While this works well for a single site, we need additional directories if we're going to serve multiple sites. We can consider the /var/www/html directory the default directory that will be served if the client request doesn't match any of our other sites.

We will create a directory structure within /var/www for each of our sites. The actual web content will be placed in an html directory within these site-specific directories. This gives us some additional flexibility to create other directories associated with our sites as siblings to the html directory if necessary.

We need to create these directories for each of our sites. The -p flag tells mkdir to create any necessary parent directories along the way:
```bash
sudo mkdir -p /var/www/example.com/html
sudo mkdir -p /var/www/test.com/html
```
Now that we have our directories, we will reassign ownership of the web directories to our normal user account. This will let us write to them without sudo.

> Note
Depending on your needs, you might need to adjust the permissions or ownership of the folders again to allow certain access to the www-data user. For instance, dynamic sites will often need this. The specific permissions and ownership requirements entirely depend on what your configuration. Follow the recommendations for the specific technology you're using.
We can use the $USER environmental variable to assign ownership to the account that we are currently signed in on (make sure you're not logged in as root). This will allow us to easily create or edit the content in this directory:
```bash
sudo chown -R $USER:$USER /var/www/example.com/html
sudo chown -R $USER:$USER /var/www/test.com/html
```

The permissions of our web roots should be correct already if you have not modified your umask value, but we can make sure by typing:
```bash
sudo chmod -R 755 /var/www
```

Our directory structure is now configured and we can move on.

 Step Two: Create Sample Pages for Each Site
Now that we have our directory structure set up, let's create a default page for each of our sites so that we will have something to display.

Create an index.html file in your first domain:
```bash
nano /var/www/example.com/html/index.html
```

Inside the file, we'll create a really basic file that indicates what site we are currently accessing. It will look like this:
```bash
/var/www/example.com/html/index.html
```
```html
<html>
    <head>
        <title>Welcome to Example.com!</title>
    </head>
    <body>
        <h1>Success!  The example.com server block is working!</h1>
    </body>
</html>
```
Save and close the file when you are finished.

Since the file for our second site is basically going to be the same, we can copy it over to our second document root like this:

```bash
cp /var/www/example.com/html/index.html /var/www/test.com/html/
```
Now, we can open the new file in our editor:

```bash
nano /var/www/test.com/html/index.html
```

Modify it so that it refers to our second domain:

```bash
/var/www/test.com/html/index.html
```
```html
<html>
    <head>
        <title>Welcome to Test.com!</title>
    </head>
    <body>
        <h1>Success!  The test.com server block is working!</h1>
    </body>
</html>
```
Save and close this file when you are finished. We now have some pages to display to visitors of our two domains.

Step Three: Create Server Block Files for Each Domain
Now that we have the content we wish to serve, we need to actually create the server blocks that will tell Nginx how to do this.

By default, Nginx contains one server block called default which we can use as a template for our own configurations. We will begin by designing our first domain's server block, which we will then copy over for our second domain and make the necessary modifications.

Create the First Server Block File
As mentioned above, we will create our first server block config file by copying over the default file:

```bash
sudo cp /etc/nginx/sites-available/default /etc/nginx/sites-available/example.com
```
Now, open the new file you created in your text editor with sudo privileges:

```bash
sudo nano /etc/nginx/sites-available/example.com
```
Ignoring the commented lines, the file will look similar to this:

```bash
/etc/nginx/sites-available/example.com
```

```nginx
server {
        listen 80 default_server;
        listen [::]:80 default_server;

        root /var/www/html;
        index index.html index.htm index.nginx-debian.html;

        server_name _;

        location / {
                try_files $uri $uri/ =404;
        }
}
```

First, we need to look at the listen directives. Only one of our server blocks on the server can have the default_server option enabled. This specifies which block should serve a request if the server_name requested does not match any of the available server blocks. This shouldn't happen very frequently in real world scenarios since visitors will be accessing your site through your domain name.

You can choose to designate one of your sites as the "default" by including the default_server option in the listen directive, or you can leave the default server block enabled, which will serve the content of the /var/www/html directory if the requested host cannot be found.

In this guide, we'll leave the default server block in place to server non-matching requests, so we'll remove the default_server from this and the next server block. You can choose to add the option to whichever of your server blocks makes sense to you.

```nginx
# /etc/nginx/sites-available/example.com
server {
        listen 80;
        listen [::]:80;

        . . .
}
```

> Note
You can check that the default_server option is only enabled in a single active file by typing:

```bash
grep -R default_server /etc/nginx/sites-enabled/
```

If matches are found uncommented in more than on file (shown in the leftmost column), Nginx will complain about an invalid configuration.

The next thing we're going to have to adjust is the document root, specified by the root directive. Point it to the site's document root that you created:

```nginx
# /etc/nginx/sites-available/example.com
server {
        listen 80;
        listen [::]:80;

        root /var/www/example.com/html;

}
```

Next, we need to modify the server_name to match requests for our first domain. We can additionally add any aliases that we want to match. We will add a www.example.com alias to demonstrate.

When you are finished, your file will look something like this:

```nginx
/etc/nginx/sites-available/example.com
server {
        listen 80;
        listen [::]:80;

        root /var/www/example.com/html;
        index index.html index.htm index.nginx-debian.html;

        server_name example.com www.example.com;

        location / {
                try_files $uri $uri/ =404;
        }
}
```
That is all we need for a basic configuration. Save and close the file to exit.

Create the Second Server Block File
Now that we have our initial server block configuration, we can use that as a basis for our second file. Copy it over to create a new file:

```bash
sudo cp /etc/nginx/sites-available/example.com /etc/nginx/sites-available/test.com
```

Open the new file with sudo privileges in your editor:

      sudo nano /etc/nginx/sites-available/test.com

Again, make sure that you do not use the default_server option for the listen directive in this file if you've already used it elsewhere. Adjust the root directive to point to your second domain's document root and adjust the server_name to match your second site's domain name (make sure to include any aliases).

When you are finished, your file will likely look something like this:

```nginx
# /etc/nginx/sites-available/test.com
server {
        listen 80;
        listen [::]:80;

        root /var/www/test.com/html;
        index index.html index.htm index.nginx-debian.html;

        server_name test.com www.test.com;

        location / {
                try_files $uri $uri/ =404;
        }
}
```

When you are finished, save and close the file.

Step Four: Enable your Server Blocks and Restart Nginx
Now that we have our server block files, we need to enable them. We can do this by creating symbolic links from these files to the sites-enabled directory, which Nginx reads from during startup.

We can create these links by typing:

```bash
sudo ln -s /etc/nginx/sites-available/example.com /etc/nginx/sites-enabled/
sudo ln -s /etc/nginx/sites-available/test.com /etc/nginx/sites-enabled/
```

These files are now in the enabled directory. We now have three server blocks enabled, which are configured to respond based on their listen directive and the server_name (you can read more about how Nginx processes these directives here):

example.com: Will respond to requests for example.com and www.example.com
test.com: Will respond to requests for test.com and www.test.com
default: Will respond to any requests on port 80 that do not match the other two blocks.
In order to avoid a possible hash bucket memory problem that can arise from adding additional server names, we will go ahead and adjust a single value within our /etc/nginx/nginx.conf file. Open the file now:

sudo nano /etc/nginx/nginx.conf
Within the file, find the server_names_hash_bucket_size directive. Remove the # symbol to uncomment the line:

/etc/nginx/nginx.conf
http {
    . . .

    server_names_hash_bucket_size 64;

    . . .
}
Save and close the file when you are finished.

Next, test to make sure that there are no syntax errors in any of your Nginx files:

sudo nginx -t
If no problems were found, restart Nginx to enable your changes:

sudo systemctl restart nginx
Nginx should now be serving both of your domain names.

Step Five: Modify Your Local Hosts File for Testing(Optional)
If you have not been using domain names that you own and instead have been using dummy values, you can modify your local computer's configuration to let you to temporarily test your Nginx server block configuration.

This will not allow other visitors to view your site correctly, but it will give you the ability to reach each site independently and test your configuration. This basically works by intercepting requests that would usually go to DNS to resolve domain names. Instead, we can set the IP addresses we want our local computer to go to when we request the domain names.

Note
Make sure you are operating on your local computer during these steps and not your VPS server. You will need to have root access, be a member of the administrative group, or otherwise be able to edit system files to do this.
If you are on a Mac or Linux computer at home, you can edit the file needed by typing:

sudo nano /etc/hosts
If you are on Windows, you can find instructions for altering your hosts file here.

You need to know your server's public IP address and the domains you want to route to the server. Assuming that my server's public IP address is 203.0.113.5, the lines I would add to my file would look something like this:

/etc/hosts
127.0.0.1   localhost
. . .

203.0.113.5 example.com www.example.com
203.0.113.5 test.com www.test.com
This will intercept any requests for example.com and test.com and send them to your server, which is what we want if we don't actually own the domains that we are using.

Save and close the file when you are finished.

Step Six: Test your Results
Now that you are all set up, you should test that your server blocks are functioning correctly. You can do that by visiting the domains in your web browser:

http://example.com
You should see a page that looks like this:

Nginx first server block

If you visit your second domain name, you should see a slightly different site:

http://test.com
Nginx second server block

If both of these sites work, you have successfully configured two independent server blocks with Nginx.

At this point, if you adjusted your hosts file on your local computer in order to test, you'll probably want to remove the lines you added.

If you need domain name access to your server for a public-facing site, you will probably want to purchase a domain name for each of your sites. You can learn how to set them up to point to your server here.

Conclusion
You should now have the ability to create server blocks for each domain you wish to host from the same server. There aren't any real limits on the number of server blocks you can create, so long as your hardware can handle the traffic.

source  : https://code.tutsplus.com/es/tutorials/apache-vs-nginx-pros-cons-for-wordpress--cms-28540



## How to setup subdomain or host multiple domains using nginx in linux server

 By Ashish Rawat    posted on 03 Jan 2017    how to's, nginx, linux tricks

Did you know, you can host multiple domains and subdomains using single ip address in linux via nginx server blocks (or virtual hosts in apache)?

Well if you don't know how to do that reading this tutorial will setup you two domains and one subdomain both pointing to the same ip address and host on the
same server.
Here's the general assumption for this setup:

  • IP Address: 220.168.32.101
  • Domain names: example.com, blog.example.com, fakenews.com

Before starting the tutorial, first thing you've to do is to point all your domains and subdomains to the single ip address via your DNS provider (edit A,
CNAME).
However if you want to test this locally, then edit the /etc/hosts configuration file and add the following:

220.168.32.101 example.com blog.example.com
220.168.32.101 fakenews.com

And when you ping these domains locally on the server, you'll get ok (200) response.

Now we'll follow the steps to setup these domain names:

1. Install and start nginx

Use the following command to install nginx on ubuntu

$ sudo apt install nginx
# now start it
$ sudo nginx

2. Test the nginx

Check any of the domains or ip address in your browser to make sure nginx works correctly. The browser will output a default nginx page.

3. Setup the test directories for each domains

Up until now, all the domains have set up correctly but there is one huge problem, all pointing to same page. We need to separate these domains to point to
their own pages. For this, I will setup test directories and html pages.

  • Creating directories for each domains and subdomain

$ cd /var/www
$ sudo mkdir example.com blog.example.com fakenews.com

  • Creating simple html pages for each

$ sudo touch example.com/index.html
$ sudo touch blog.example.com/index.html
$ sudo touch fakenews.com/index.html

  • Lastly put some different content in each index.html files

4. Creating server blocks for each domains and subdomain

Nginx provide default server block in /etc/nginx/sites-available. We will copy that server block for each domains and do modifications for each.
Also we will create symbolic link of new file

## For example.com domain
$ sudo cp /etc/nginx/sites-available/default /etc/nginx/sites-available/example.com
$ sudo ln -s /etc/nginx/sites-available/example.com /etc/nginx/sites-enabled/example.com
## similarly do for others also.

Now after modification, the new file will look like this for example.com domain

server {
        listen 80 default_server;
        listen [::]:80 default_server;
        root /var/www/example.com;
        index index.html;
        server_name example.com;
}

Here default_server means if none of the other domains resolve, the last resort is to resolve this server block.

    NOTE: There is only one default server block in nginx with same port.

Similarly for other two domains the configuration are:

## For blog.example.com subdomain
server {
        listen 80;
        listen [::]:80;
        root /var/www/blog.example.com;
        index index.html;
        server_name blog.example.com;
}

## For fakenews.com domain
server {
        listen 80;
        listen [::]:80;
        root /var/www/fakenews.com;
        index index.html;
        server_name fakenews.com;
}

Bonus: Suppose fakenews.com domain listen on different port (say 2368 port) and you want to proxying port in nginx to default 80 port, then you can use
location block inside server block like this:

server {
   ## other configuration as above
    # ...
  location {
     proxy_pass http://127.0.0.1:2368;
     proxy_set_header X-Real-IP $remote_addr;
     proxy_set_header HOST $http_host;
  }
}






#### Some point over cakephp configuration

example
```lua
server {
      listen      80;
      server_name remote.inodd.com;
      ## redirect http to https ##
      rewrite        ^ https://$server_name$request_uri? permanent;
}

server {
#       listen   80;
    listen       443 ssl;
    server_name  remote.inodd.com;
    ssl_certificate /home/vhost/www/domain/ssl/self-ssl.crt;
    ssl_certificate_key /home/vhost/www/domain/ssl/self-ssl.key;
    access_log /home/vhost/www/domain/logs/access_log;
    error_log /home/vhost/www/domain/logs/error_log;

        location / {
                root   /home/vhost/www/domain/public_html/development/webroot;
                index  index.php index.html index.htm;

                if (-f $request_filename) {
                        break;
                }

                if (-d $request_filename) {
                        break;
                }
                rewrite ^(.+)$ /index.php?q=$1 last;
        }

        location ~ .*\.php[345]?$ {
                include fastcgi_params;
                fastcgi_pass    unix:/var/run/php-fpm/php-fpm.sock;
                fastcgi_index   index.php;
                fastcgi_param SCRIPT_FILENAME
                /home/vhost/www/domain/public_html/development/webroot$fastcgi_script_name;
        }
}
```

from official webdav


nginx

nginx does not make use of .htaccess files like Apache, so it is necessary to create those rewritten URLs in the site-available configuration. This is usually found in /etc/nginx/sites-available/your_virtual_host_conf_file. Depending on your setup, you will have to modify this, but at the very least, you will need PHP running as a FastCGI instance. The following configuration redirects the request to webroot/index.php:

```lua
location / {
    try_files $uri $uri/ /index.php?$args;
}

A sample of the server directive is as follows:

server {
    listen   80;
    listen   [::]:80;
    server_name www.example.com;
    return 301 http://example.com$request_uri;
}

server {
    listen   80;
    listen   [::]:80;
    server_name example.com;

    root   /var/www/example.com/public/webroot;
    index  index.php;

    access_log /var/www/example.com/log/access.log;
    error_log /var/www/example.com/log/error.log;

    location / {
        try_files $uri $uri/ /index.php?$args;
    }

    location ~ \.php$ {
        try_files $uri =404;
        include fastcgi_params;
        fastcgi_pass 127.0.0.1:9000;
        fastcgi_index index.php;
        fastcgi_intercept_errors on;
        fastcgi_param SCRIPT_FILENAME $document_root$fastcgi_script_name;
    }
}
```

>Recent configurations of PHP-FPM are set to listen to the unix php-fpm socket
instead of TCP port 9000 on address 127.0.0.1. If you get 502 bad gateway errors
from the above configuration, try update fastcgi_pass to use the unix socket path
 (eg: fastcgi_pass unix:/var/run/php/php7.1-fpm.sock;) instead of the TCP port.


####  Configurando PHP FPM Con Apache

Los usuarios Ubuntu y Debian pueden instalar los paquetes requeridos con aptitude vía:

sudo apt-get -y install libapache2-mod-fastcgi php7.0-fpm php7.0
Ahora habilita el módulo en apache:

a2enmod actions fastcgi alias
Después, en el archivo de configuración /etc/apache2/conf-available/php7.0-fpm.conf, agrega lo siguiente:

<IfModule mod_fastcgi.c>
    AddHandler php7-fcgi .php
    Action php7-fcgi /php7-fcgi
    Alias /php7-fcgi /usr/lib/cgi-bin/php7-fcgi
    FastCgiExternalServer /usr/lib/cgi-bin/php7-fcgi -socket /var/run/php/php7.0-fpm.sock -pass-header Authorization
</IfModule>
También, en tu VirtualHost para WordPress (ruta por defecto /etc/apache2/sites-available/000-default.conf), agrega lo siguiente:

<Directory /usr/lib/cgi-bin>
    Require all granted
</Directory>
<IfModule mod_fastcgi.c>
    SetHandler php7-fcgi .php
    Action php7-fcgi /php7-fcgi virtual
    Alias /php7-fcgi /usr/lib/cgi-bin/php7-fcgi
    FastCgiExternalServer /usr/lib/cgi-bin/php7-fcgi -socket /var/run/php/php7.0-fpm.sock -pass-header Authorization
</IfModule>
Ahora reinicia apache y estás listo para seguir


systemctl restart apache2.service
Haz un archivo <?php phpinfo(); ?> y mira en tu navegador. PHP ahora estará sirviendo como FPM.

Ahora revisa tu blog WordPress. ¿Notas alguna diferencia?

Configurando PHP FPM Con Nginx
Los usuarios Ubuntu y Debian pueden instalar el paquete con lo siguiente:

apt-get -y install php7.0-fpm
Ahora, dentro de tu archivo de configuración (default /etc/nginx/sites-available/default) en el bloque del servidor, necesitas agregar la configuración FastCGI como sigue:

server {
...
 location / {
    # use try files to try and serve the file
    try_files $uri $uri/ =404;
 }

 # PHP FPM Configuration
 location ~ \.php$ {
    include snippets/fastcgi-php.conf;

    # Connect via socket
    fastcgi_pass unix:/run/php/php7.0-fpm.sock;
 }

 # deny apache .htaccess requests
 location ~ /\.ht {
  deny all;
 }
 ...
 }
Aquí usamos el snippet de Nginx para establecer los parámetros cgi y pasar a fastcgi el socket de conexión.

Después, asegúrate de que estableces el cgi.fix_pathinfo=0 en el php ini, ya que el ajuste por defecto está rompiendo la configuración. Edita /etc/php/7.0/fpm/php.ini y establece:

[...]
; cgi.fix_pathinfo provides *real* PATH_INFO/PATH_TRANSLATED support for CGI.  PHP's
; previous behaviour was to set PATH_TRANSLATED to SCRIPT_FILENAME, and to not grok
; what PATH_INFO is.  For more information on PATH_INFO, see the cgi specs.  Setting
; this to 1 will cause PHP CGI to fix its paths to conform to the spec.  A setting
; of zero causes PHP to behave as before.  Default is 1.  You should fix your scripts
; to use SCRIPT_FILENAME rather than PATH_TRANSLATED.
; http://php.net/cgi.fix-pathinfo
cgi.fix_pathinfo=0
[...]
Ahora puedes guardar el archivo, y recargar PHP FPM. Haz esto vía:

1
service php7.0-fpm reload
Finalmente, podemos revisar el <?php phpinfo(); ?> en un navegador para confirmar que el servidor está usando ahora PHP FPM con Nginx.

Haciendo mod_rewrite en Nginx
Nginx no usa un archivo .htaccess, y para re-escritura URL tiene una aproximación mucho más simple.

Para hacer que tu blog WordPress funcione con Nginx, simplemente agrega lo siguiente a la parte try_files de tu configuración Nginx:

location / {
    index index.php index.html index.htm;
    try_files $uri $uri/ /index.php?q=$uri&$args;
}
Si estás usando un directorio para tu blog WordPress, por favor establece lo siguiente:

location /wordpress/ {
    try_files $uri $uri/ /index.php?q=$uri&$args;
}
Reinicia Nginx y tendrás funcionando re-escritura URL.

$ service nginx restart
Configuraciones Óptimas
Tienes muchas opciones para optimizar WordPress vía cacheando en el servidor vía memcache, varnish y también en el nivel de app WordPress con complementos que te permitirán acceder fácilmente a esto.

Sin embargo, lo que te da Nginx es una gran solución para servir contenido web estático con su robusta y rápida caché de contenido estático.

Caché de Contenido Estático
Nginx es muy rápido cuando se usa como un caché de contenido estático, y es aquí en donde su uso realmente sobresale en términos de WordPress y publicaciones con muchas imágenes. Puedes servir tu CSS, JS e imágenes todo vía un servidor Nginx ejecutándose solo para estas necesidades.

Siempre es mejor hacer esto en un dominio sin cookies para que el contenido sea realmente cacheado por el navegador (ya que la cookie no es cacheable), así que usar un sub-dominio tal como images.myblog.com o static.myblog.com sería ideal.

Un bloque de ubicación para estos sub-dominios estáticos de configuración debería lucir así:

location ~* ^.+\.(?:css|cur|js|jpe?g|gif|htc|ico|png|html|xml|otf|ttf|eot|woff|svg)$ {
    access_log off;
    expires 30d;
    tcp_nodelay off;
    ## Set the OS file cache.
    open_file_cache max=3000 inactive=120s;
    open_file_cache_valid 45s;
    open_file_cache_min_uses 2;
    open_file_cache_errors off;
}
Usando open_file_cache, habilitamos el cacheo para nuestros archivos de medios estáticos. Especificamos el máximo de archivos a cachear y por cuánto tiempo con open_file_cache max=3000 inactive=120s;

si quieres configurar el cacheo en todo el proyecto, solo agrega las siguientes cuatro líneas en tus configuraciones nginx.conf:

open_file_cache          max=10000 inactive=5m;
open_file_cache_valid    2m;
open_file_cache_min_uses 1;
open_file_cache_errors   on;
Importante: El open_file_cache_errors cacheará los errores 404 actuales, así que es mejor apagar esto si estás usando un balanceador de carga en conjunto con esto.

Pilas de Conexión PHP-FPM
Es posible usar diferentes pilas para cada WordPress diferente, y puedes después colocar recursos muy precisamente para cada sitio---incluso usando diferentes usuarios y grupos para cada pila si se necesita. La configuración es muy flexible.

Puedes establecer varias configuraciones, por ejemplo:

/etc/php-fpm.d/family-site.conf
/etc/php-fpm.d/travel-blog.conf
/etc/php-fpm.d/cooking-recipes.conf
En cada uno de los siguientes, podemos establecer una plétora de configuraciones como:

[site]
listen = 127.0.0.1:9000
user = user
group = websites
request_slowlog_timeout = 5s
slowlog = /var/log/php-fpm/slowlog-site.log
listen.allowed_clients = 127.0.0.1
pm = dynamic
pm.max_children = 5
pm.start_servers = 3
pm.min_spare_servers = 2
pm.max_spare_servers = 4
pm.max_requests = 200
listen.backlog = -1
pm.status_path = /status
request_terminate_timeout = 120s
rlimit_files = 131072
rlimit_core = unlimited
catch_workers_output = yes
env[HOSTNAME] = $HOSTNAME
env[TMP] = /tmp
env[TMPDIR] = /tmp
env[TEMP] = /tmp
Con esto, puedes especificar las opciones de configuración PHP-FPM tales como pm.max_children, y también puedes especificar variables ambientales y establecer los ajustes de nombre de usuario y grupo aquí.

Balanceador de Carga Nginx
Si vas a tener mucho tráfico entonces probablemente querrás establecer un balanceador de carga para usar con tu configuración php-fpm.

Convencionalmente, querremos iniciar varios servidores de río arriba back-end, de los cuáles todos están ejecutando espejos de tu blog, y después tener otro servidor ejecutando nginx en frente de este el cuál está actuando como un balanceador de carga y dirigirá la carga entre los flujos.

Esto significa que puedes usar muchos servidores para alimentar tu blog de una vez, y la configuración para hacerlo es relativamente sencilla.

Un ejemplo de configuración luciría como esto. Primero comenzamos con un módulo río arriba:

upstream backend  {
  server backend1.example.com;
  server backend2.example.com;
  server backend3.example.com;
}
Aquí, cada backend1.example.com tiene su propia configuración Nginx, un espejo de cómo el sitio estaba antes de que tuviera un balanceador de carga. Nginx elegirá cuál servidor usar para cada petición.

Si uno de nuestros back ends tiene un disco duro más rápido, como SSD por ejemplo, o si está geográficamente más cercano a tu base principal de usuarios, puedes establecer ponderación así:

upstream backend  {
  server backend1.example.com weight=1;
  server backend2.example.com weight=2;
  server backend3.example.com weight=4;
}
De manera adicional, si crees que un servidor podría venirse abajo o estás preocupado por tiempos fuera, también hay opciones de configuración para esto:

upstream backend  {
  server backend1.example.com max_fails=3  fail_timeout=15s;
  server backend2.example.com weight=2;
  server backend3.example.com weight=4;
Ahora, con esta configuración, después de tres fallos o un tiempo de espera de 15 segundos, el servidor y ano será usado por el balanceador de carga. Si deseas marcar manualmente un servidor como inactivo, agrega la palabra clave down, ej. server backend3.example.com down;.

Después necesitamos pasar eso al servidor vía proxy usando el flujo backend que acabamos de definir:

server {
  location / {
    proxy_pass  http://backend;
  }
}
Ahora reinicia tu servidor con service nginx restart, ¡y estás ejecutando una versión de carga balanceada de tu sitio!


##### nginx & cakephp

 sudo apt-get install php7.2-intl php7.2-mbstring php7.2-simplexml php7.2-zip


### :fa-code: Improvements FMP

source  https://pehapkari.cz/blog/2017/03/27/multiple-php-versions-the-easy-way/
In Debian systems , can install both php version 5.6 and 7

### Installing PHP 7.0

Install PHP 7.0 from Debian archive. This will be (sadly) the default version in Stretch, 7.1 came out too late to squeeze into Stretch's timeline. Do this using the following command:
```bash
$ apt-get install php7.0-cli php7.0-fpm
```
Notice the different pattern of the package name. Older Debian installations used simply php5 whereas newer infrastructure uses phpX.Y. This is the obvious part that efficiently allows us to use multiple PHPs in parallel. With this structure, you can install each of the minor versions next to each other.
### Installing PHP 5.6

Here's the catch. Debian only offers a single PHP version in the official repository. Fortunately there are packages directly from a maintainer of Debian's PHP packages, Ondřej Surý. Visit his page about packaging to learn more. (There is also a PPA repository in case you'd rather use Ubuntu instead of Debian.)

We'll now add his repository (as well as enable HTTPS for APT and register the APT key):
```bash
$ apt-get install apt-transport-https
$ curl https://packages.sury.org/php/apt.gpg | apt-key add -
$ echo 'deb https://packages.sury.org/php/ stretch main' > /etc/apt/sources.list.d/deb.sury.org.list
$ apt-get update
```
Now that we have the repository added, we can install the packages from there:
```bash
$ apt-get install php5.6-cli php5.6-fpm
```
This will install PHP 5.6 in parallel to PHP 7.0 installed earlier. We can check this is true by simply running:
```bash
$ php7.0 -v
PHP 7.0.15-1 (cli)
$ php5.6 -v
PHP 5.6.30-5+0~20170223133422.27+stretch~1.gbp1ee0cb (cli)
```
Note that for conviniency there is also a php command provided by alternatives (which defaults to the newest version):
```bash
$ php -v
PHP 7.0.15-1 (cli)
```
You can switch the default version using update-alternatives, just run the following command and pick the version you prefer:

```bash
$ update-alternatives --config php

There are 2 choices for the alternative php (providing /usr/bin/php).

  Selection    Path             Priority   Status
------------------------------------------------------------
  0            /usr/bin/php7.2   72        auto mode
* 1            /usr/bin/php5.6   56        manual mode
  2            /usr/bin/php7.2   72        manual mode

Press <enter> to keep the current choice[*], or type selection number:
```


install the needed module
> libapache2-mod-php5.6

or
> libapache2-mod-php7.2

as default

change between versions



```bash
#change to 7.2
sudo a2dismod php7.2 ; sudo a2enmod php5.6 ; sudo systemctl restart apache2 ; sudo update-alternatives --set php /usr/bin/php7.2

#change to 5.6
sudo a2dismod php5.6 ; sudo a2enmod php7.2 ; sudo systemctl restart apache2 ; sudo update-alternatives --set php /usr/bin/php5.6
```

OR use multiple php version :



First of all, ensure all the PHP related configraution are disabled by run the following commands:

#### ls -la /etc/apache2/conf-enabled | grep php
#### ls -la /etc/apache2/mods-enabled | grep php

Set up a different version of PHP-FPM for a specific site:
Add the following line in your existing VirtualHost file.
Include "conf-available/php7.2-fpm.conf"
For example,

#### vim /etc/apache2/sites-enabled/symfony.local.conf

```conf
<VirtualHost *:80>
    ServerName symfony.local

    Include "conf-available/php7.2-fpm.conf"

    ServerAdmin webmaster@localhost
    DocumentRoot /var/www/symfony.local/curr/public

    <Directory /var/www/symfony.local/curr/web>
        AllowOverride All
    </Directory>
</VirtualHost>
```

 if we want a defautl php 7.2 then

 sudo a2disconf php5.6-fpm.conf
 sudo a2enconf php7.2-fpm.conf

and add the proper include in virtual host file
 Include "conf-available/php7.2-fpm.conf"

 for a 5.6 version as default just do the invert steps

 for mod_rewrite

 in apache.config


```conf
 <Directory />
    Options FollowSymLinks
    AllowOverride All
</Directory>
<Directory /var/www>
    Options Indexes FollowSymLinks MultiViews
    AllowOverride All
    Order Allow,Deny
    Allow from all
</Directory>
```

or in virtual host file

Inside that file, you will find a `<VirtualHost *:80>` block starting on the first line. Inside of that block, add the following new block so your configuration file looks like the following. Make sure that all blocks are properly indented.
/etc/apache2/sites-available/000-default.conf

  ```conf
  <VirtualHost *:80>
      <Directory /var/www/html>
          Options Indexes FollowSymLinks MultiViews
          AllowOverride All
          Require all granted
      </Directory>

      . . .
  </VirtualHost>
  ```


searhc for a libs
ldd `which mplayer` | grep --color libbs2b.so.0



check for This

NOTICE: Not enabling PHP 5.6 FPM by default.
NOTICE: To enable PHP 5.6 FPM in Apache2 do:
NOTICE: a2enmod proxy_fcgi setenvif
NOTICE: a2enconf php5.6-fpm
NOTICE: You are seeing this message because you have apache2 package installed.



check on nginx method

### Enabling error display in php via htaccess only

```init
php_flag display_startup_errors on
php_flag display_errors on
php_flag html_errors on
php_flag  log_errors on
php_value error_log  /home/path/public_html/domain/PHP_errors.log
```

### Setting up multiple apache2 instances on Ubuntu 16.04

src:https://gist.github.com/aaronbloomfield/92c707631a0191152bc7faf0124fd651

PHP handling on apache is done via modules of one sort or another, and running multiple version is problematic on a single instance.  The solution is to run two instances of apache on the same machine.  This allows one instance to run PHP 7 (the default on 16.04), and another can run PHP 5.  Since normal http/https is on ports 80 and 443, the second instance will run on ports 81 and 444.  Since it is running on the same machine, all file system and database access is the exact same.

All the commands herein have to be run as root, or with `sudo` prefixed to the command.

1. Read /usr/share/doc/apache2/README.multiple-instances

2. Run `sh ./setup-instance php5` from `/usr/share/doc/apache2/examples`, where `php5` is the suffix for the second site; all commands for the second site will have that suffix.  This will keep all of the same configuration for all sites on the new instance, including SSL certificates, other virtual hosts, etc.  After running this command, you will see output like this:

```bash
Setting up /etc/apache2-php5 ...
systemd is in use, no init script installed
use the 'apache2@php5.service' service to control your new instance
sample commands:
systemctl start apache2@php5.service
systemctl enable apache2@php5.service
Setting up symlinks: a2enmod-php5 a2dismod-php5 a2ensite-php5 a2dissite-php5 a2enconf-php5 a2disconf-php5 apache2ctl-php5
Setting up /etc/logrotate.d/apache2-php5 and /var/log/apache2-php5 ...
Setting up /etc/default/apache-htcacheclean-php5
```

3. Install PHP 5: see http://askubuntu.com/questions/756181/installing-php-5-6-on-xenial-16-04 for the source of the directions for this step
   - `add-apt-repository ppa:ondrej/php`
   - `apt-get update`
   - `apt-get install php5.6 php5.6-mbstring php5.6-mcrypt php5.6-mysql php5.6-xml`

4. Change line 1 of `/etc/apache2-php5/mods-available/php5.load` to use the correct path (likely `/usr/lib/apache2/modules/libphp5.6.so`).  Alternatively, one can use the `php5.6.load` and `php5.6.conf` files installed in `/etc/apache2/mods-available` (these will have to be moved to `/etc/apache2-php5/mods-available`).

5. You may have to configure `/etc/apache2-php5/mods-available/php5.conf` (or `php5.6.conf`), for example, setting `php_admin_flag engine On` for the users' home directories.

6. On the second instance, disable anything that will conflict with the default PHP 5 module; for me this was disabling FastCGI and FPM, but yours may have php7.0; both are listed below.  Also enable PHP 5.  Note that PHP 5 was likely enabled on the default web server via the installation of the php5.6 package, so that needs to be disabled.  Note that depending on what you did in step 4, you may have to replace "php5.6" below with "php5".  Also note that some of these modules and configurations that are being disabled may not exist on your system -- that's fine.

```bash
a2dismod-php5 php7.0
a2dismod-php5 fastcgi
a2enmod-php5 php5.6
a2disconf-php5 php7.0-fpm
a2dismod-php5 proxy_fcgi
a2dismod php5.6
```

7. ~~Remove /etc/apache2-php5/userperms.conf, if it exists, and replace with empty file (that is a FastCGI/FPM file, which is not needed in PHP5, which is not being configured here to use FastCGI/FPM).~~ (this was only for my local configuration)

8. Make sure the porst you want to use (81/444 in this example) are available: run `nmap localhost` (you may have to install the `nmap` package first) to see which ports are currently in use.  To find the processes running on a given port, run `lsof -i :81` (replace 81 with the port you are investigating).

9. In /etc/apache-php5/, edit ports.conf, and change ports 80 and 443 to the ports that you want to use (81 and 444, in this example).

10. In /etc/apache-php5/sites-available/, edit 000-default.conf, default-ssl.conf, and any other web site configuration files that you want running on the second instance.  The port numbers have to be changed there as well (from 80/443 to 81/444).

11. Although the new service (`apahce2-php5`) was installed (in `/etc/init.d/`), the system isn't aware of it yet.  To fix this, see the commands listed in `/usr/share/doc/apache2/README.multiple-instances` (which one you use will vary depending on your system).

12. Restart apache2: `service apache2-php5 restart`

At this point, it should work: using the regular ports for http/https (i.e., no port number) will use PHP 7.  Using ports 81/444 for http/https, respectively, will use PHP 5.  For example: http://example.com:81/phpinfo.php and https://example.com:444/phpinfo.php.

### Setting Database Server [mariadb]

After install mariadb server and client

Secure database server

run the mysql_secure_installation script to secure the database where you can:

    set root password (if not set in the configuration step above).
    disable remote root login
    remove test database
    remove anonymous users and
    reload privileges
```bash
$ sudo mysql_secure_installation
```

##### Some improvements


The "unix_socket" has been called by mysql authentication process (maybe related to a partial migration of database to mariadb, now removed). To get all stuff back working go su:

sudo su

then follow:

/etc/init.d/mysql stop
mysqld_safe --skip-grant-tables &
mysql -uroot

This will completely stop mysql, bypass user authentication (no password needed) and connect to mysql with user "root".

Now, in mysql console, go using mysql administrative db:

use mysql;

To reset root password to mynewpassword (change it at your wish), just to be sure of it:

update user set password=PASSWORD("mynewpassword") where User='root';

And this one will overwrite authentication method, remove the unix_socket request (and everything else), restoring a normal and working password method:

update user set plugin="mysql_native_password";

Exit mysql console:

quit;

Stop and start everything related to mysql:

/etc/init.d/mysql stop
kill -9 $(pgrep mysql)
/etc/init.d/mysql start

Don't forget to exit the su mode.

Now mySQL server is up and running. You can login it with root:

mysql -u root -p

or whatever you wish. Password usage is operative.

That's it.


###### Open file limits

The open file limits is not a performance relevant setting, but running a benchmark with a lot of concurrent users can hit the open file limit quite easy.
On most Linux systems the open file limit is at 1024, which may not be enough. Set your open file limit higher by editing

> $EDITOR /etc/security/limits.conf

and adding a line like
```bash
#ftp             hard    nproc           0
#@student        -       maxlogins       4
*                -       nofile          16384
# End of file
```
Your ""ulimit -a"" output should look like this afterwards:
```bash
ulimit -a
core file size          (blocks, -c) 0
data seg size           (kbytes, -d) unlimited
scheduling priority             (-e) 0
file size               (blocks, -f) unlimited
pending signals                 (-i) 15975
max locked memory       (kbytes, -l) 64
max memory size         (kbytes, -m) 1744200
open files                      (-n) 16384
```

##### How to Create a New User in Maria

a new user within the MySQL shell:

```sql
CREATE USER 'newuser'@'localhost' IDENTIFIED BY 'password';
```

Sadly, at this point newuser has no permissions to do anything with the databases. In fact, if newuser even tries to login (with the password, password), they will not be able to reach the MySQL shell.

Therefore, the first thing to do is to provide the user with access to the information they will need.

```sql
GRANT ALL PRIVILEGES ON *.* TO 'newuser'@'localhost';
-- or for grants
grant all privileges on *.* to 'newuser'@'localhost' with grant option;
```
The asterisks in this command refer to the database and table (respectively) that they can access—this specific command allows to the user to read, edit, execute and perform all tasks across all the databases and tables.

Once you have finalized the permissions that you want to set up for your new users, always be sure to reload all the privileges.

```sql
FLUSH PRIVILEGES;
```
Your changes will now be in effect.

### Configure connection from LAMP to MSSQL

> firts install lamp

``` bash
apt-get install apache2 mysql-server mysql-client php5-cli php5 php5-mysql
```
then add modrewrite module to apache

``` bash
a2enmod rewrite
```

change in /etc/apache2/apache.conf

```xml
<Directory>
/var/www/
AllowOverride none
to
AllowOverride All
</Directory>
```

Restart apache Service

Allowed memory size of 147281674 bytes exhausted in <some-file>.php on line 57
Then you start to search on the Internet with the above error message and you find advices like:
memory_limit = 32M to your server’s main php.ini file (recommended, if you have access)
memory_limit = 32M to a php.ini file in your application’s php file
ini_set(‘memory_limit’, ’32M’); ini_set(‘memory_limit’, ’-1’); in your sites/default/settings.php file
php_value memory_limit 32M in your .htaccess file
Add more memory

The easiest way to find is to access the phpinfo() function on your system by launching a web-browser and typing the name (or IP address) of your Debian server like this:

and look for the following entry:
Loaded Configuration File etc/php5/apache2/php.ini
that is basically where your global php.ini file resides on your system.
Any application that uses Apache will read the value of the parameter:
memory_limit = 128M
 in cakephp overerite the .htaccess of the individual application
 are in the root directory

        myApp/
          app/
          config/
          cake/
          .../
          .htaccess

app.php Configuration examples



for database connections

```php
'Datasources' => [
  // NOTE the local mariadb server
    'default' => [
        'className' => 'Cake\Database\Connection',
        'driver' => 'Cake\Database\Driver\Mysql',
        'persistent' => false,
        'host' => 'localhost',
        /*
         * CakePHP will use the default DB port based on the driver selected
         * MySQL on MAMP uses port 8889, MAMP users will want to uncomment
         * the following line and set the port accordingly
         */
        //'port' => 'non_standard_port_number',
        'username' => 'blackops',
        'password' => '@blackops#',
        'database' => 'blackops',
        /*
         * You do not need to set this flag to use full utf-8 encoding (internal default since CakePHP 3.6).
         */
        //'encoding' => 'utf8mb4',
        'timezone' => 'UTC',
        'flags' => [],
        'cacheMetadata' => true,
        'log' => false,

        /**
         * Set identifier quoting to true if you are using reserved words or
         * special characters in your table or column names. Enabling this
         * setting will result in queries built using the Query Builder having
         * identifiers quoted when creating SQL. It should be noted that this
         * decreases performance because each query needs to be traversed and
         * manipulated before being executed.
         */
        'quoteIdentifiers' => false,

        /**
         * During development, if using MySQL < 5.6, uncommenting the
         * following line could boost the speed at which schema metadata is
         * fetched from the database. It can also be set directly with the
         * mysql configuration directive 'innodb_stats_on_metadata = 0'
         * which is the recommended value in production environments
         */
        //'init' => ['SET GLOBAL innodb_stats_on_metadata = 0'],

        'url' => env('DATABASE_URL', null),
    ],

    // NOTE Connecting to a mssql server in the work

    'MssqlWork' => [
                'className' => 'Cake\Database\Connection',
                'driver' => 'Cake\Database\Driver\Sqlserver',
                'persistent' => false,
                'host' => '192.168.20.235',
                'port' => '1433',
                'username' => 'zam',
                'password' => 'lis',
                // 'database' => 'sistemas',
                'encoding' => 65001,
                'timezone' => 'UTC',
                'cacheMetadata' => true,
                'log' => false,
                'quoteIdentifiers' => false,
                'url' => env('DATABASE_URL', null)
      ],
]
```



#### Backup your databases

```bash
#!/bin/bash
mysqldump -u root -p --all-databases > alldb_backup.sql
# or
mysqldump -h server -u root -p --all-databases > all_dbs.sql
# and
mysql -u root -p < all_dbs.sql
# other options
mysqldump [options] --databases db_name1 [db_name2 db_name3...]

mysqldump -u SomeUser -p --databases mydb1 mydb2 mydb3 > myDbs.sql
```

```bash
# backup databases example
mysqldump -u root -p --databases policies portal_company portal_secure portal_user_info portal_users > integradev.sql

mysql -u ambagasdowa -p < integradev.sql
```

## Dump and restore a single table from .sql

#### Dump

mysqldump db_name table_name > table_name.sql

#### Dumping from a remote database

mysqldump -u <db_username> -h <db_host> -p db_name table_name > table_name.sql

For further reference:
http://www.abbeyworkshop.com/howto/lamp/MySQL_Export_Backup/index.html

> TITLE => connect cakephp/LinuxBox To MSSQL

Summary

install the packages

    freetds-bin
    tdsodbc
    unixodbc
    php5-sybase


=== Add the server Definition Entry in

> /etc/freetds/freetds.conf


hostidentifier => the name of the server this is a wrapper for the connection

``` ini
[hostidentifier]
host = 192.168.0.30
port = 1433
tds version = 8.0
```

* Add the driver configuration /etc/odbcinst.ini
* the routes in debian are /usr/lib/i386-linux-gnu/odbc/libtdsodbc.so
* and /usr/lib/i386-linux-gnu/odbc/libtdsS.so

*  for x64 systems the routes are :
*  Driver = /usr/lib/x86_64-linux-gnu/odbc/libtdsodbc.so
*  Setup = /usr/lib/x86_64-linux-gnu/odbc/libtdsS.so

``` ini
[ms-sql]
Description = TDS connection
Driver = /usr/lib/libtdsodbc.so.0
Setup = /usr/lib/libtdsS.so
UsageCount = 1
FileUsage = 1
```

* Add the connection configuration /etc/odbc.ini

``` ini
[odbc-dbname]
Description = sqlserver1
Driver = ms-sql
ServerName = hostsql1
UID = TuUsuario
Port = 1433
Database = dbname
```

Driver debe de ser el nombre del driver que hemos definido en odbcinst.ini
ServerName debe de ser el identificador de host que hemos definido en freetds.conf

* Test the connection

``` bash
# tsql -S 192.168.0.30 -p 1433 -U TuUsuario -P TuPassword
locale is “en_US.UTF-8″
locale charset is “UTF-8″
1>
```


``` bash
# isql -v odbc-dbname TuUsuario TuPassword

| Connected!                            |
|                                       |
| sql-statement                         |
| help [tablename]                      |
| quit                                  |
|                                       |
+—————————————+

SQL>
```

``` bash
apt-get install libsybdb5 freetds-common php5-sybase
/etc/init.d/apache2 restart
```

At the end of the process, if all goes fine, you will find in the mssql section of phpinfo();

Additionally in cakephp

I corrected the problem by adding the 'port' => '' to my database.php
default config as in:

``` php

  var $default = array(
          'driver' => 'mssql',
          'persistent' => false,
          'host' => 'hostidentifier',
          'login' => 'sa',
          'password' => 'pass',
          'database' => 'MyDb',
          'encoding' => 'utf8',
          'port' => '1433'
  );

```

   Happy coding!


# :fa-video-camera: Screencast

* capture image example
```bash
      ffmpeg -f x11grab -r 25 -s 1440x900 -i :0.0 -vcodec huffyuv screencast.avi
      # then Recommended
      ffmpeg -i screencast.avi -vf scale=320:-1 -r 10 -f image2pipe -vcodec ppm - | convert -fuzz 4% -layers Optimize -delay 5 -loop 0 - output.gif
      # OR
# output as gif
      ffmpeg -i screencast.avi -loop_output 0 -r 5 -s 320x200 -pix_fmt rgb24 output.gif
      # OR
      ffmpeg -i screencast.avi -pix_fmt rgb24 output.gif
# finally
      convert output.gif -fuzz 8% -layers Optimize finalgif.gif

```


# Atom Editor

##### track packages in Atom editor
To track installed packages as well, you will need to run:

```sh
apm list --installed --bare > ~/.atom/package.list
```
And add that file to Git also. To restore, use:

```sh
apm install --packages-file ~/.atom/package.list
```

# Fonts install

#### Manual Instalation

There are various locations in GNU/Linux in which fonts can be kept. These locations are defined in /etc/fonts/fonts.conf; standard ones include /usr/share/fonts, /usr/local/share/fonts, and ~/.fonts.

The easiest way to install a truetype font is to press alt-F2 and enter the following code (this will open nautilus in the right directory):

gksu nautilus /usr/share/fonts/truetype

Then create a new directory, name the directory whatever you like (choose a name that you remember) and copy the fonts into that directory

If you need to backup your personal fonts, you should use the ~/.fonts/ folder. To create the folder and install the font "Example.otf":

sudo mkdir -p "~/.fonts/truetype/choose_a_font_folder_name_here"
sudo cp Example.otf "~/.fonts/truetype/choose_a_font_folder_name_here"

Not always needed, but finally you can additionally rebuilding the font information files by pressing alt-F2, mark 'run in terminal' so you can see the progress and entering the following code:
```bash
sudo fc-cache -f -v
```

search a font
```bash
fc-list | grep -i "media"
```
Also give a try to fc-scan, fc-match


### ppa-keys issue

The command should throw a similar warning:
Code:

```bash
Reading package lists... Done
#W: GPG error: http://deb.opera.com stable Release: The following signatures couldn't be verified because the public
key is not available: NO_PUBKEY F9A2F76A9D1A0061
W: You may want to run apt-get update to correct these problems
```

type:
Code:

```bash
sudo apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 9D1A0061
```

where 9D1A0061 are the last 8 digits from the public key mentioned in the warning.
and:
Code:

sudo apt-get update


# :fa-gitlab: Gitlab
Command line instructions
Git global setup

git config --global user.name "へすす  あるべると Baizabal"
git config --global user.email "ambagasdowa@gmail.com"

Create a new repository

git clone https://gitlab.com/ambagasdowa/landing.git
cd landing
touch README.md
git add README.md
git commit -m "add README"
git push -u origin master

Existing folder

cd existing_folder
git init
git remote add origin https://gitlab.com/ambagasdowa/landing.git
git add .
git commit -m "Initial commit"
git push -u origin master

Existing Git repository

cd existing_repo
git remote rename origin old-origin
git remote add origin https://gitlab.com/ambagasdowa/landing.git
git push -u origin --all
git push -u origin --tags


# :fa-github: Git docs


##### update a repo to github
cd to path
```bash
git status
git add .
git commit -m "some description"
git push
```
##### Update a repo to local

```bash
git pull
```

How to ignore error on git pull about my local changes would be overwritten by merge?

try one :
Alright with the help of the other two answers I've come up with a direct solution:

```bash
git checkout HEAD^ file/to/overwrite
git pull
```

try two (working for nextcloud):
This works for me to override all local changes and does not require an identity:
```bash
git reset --hard
git pull
```


##### Create a repo from command line

Create a new repository on GitHub. To avoid errors, do not initialize the new repository with README, license, or gitignore files. You can add these files after your project has been pushed to GitHub.
Open Terminal.

Change the current working directory to your local project.

Initialize the local directory as a Git repository.

git init
Add the files in your new local repository. This stages them for the first commit.

git add .
* Adds the files in the local repository and stages them for commit. To unstage a file, use 'git reset HEAD YOUR-FILE'.
Commit the files that you've staged in your local repository.

git commit -m "First commit"
* Commits the tracked changes and prepares them to be pushed to a remote repository. To remove this commit and modify the file, use 'git reset --soft HEAD~1' and commit and add the file again.
Copy remote repository URL fieldAt the top of your GitHub repository's Quick Setup page, click  to copy the remote repository URL.

In Terminal, add the URL for the remote repository where your local repository will be pushed.

git remote add origin remote repository URL
* Sets the new remote
git remote -v
* Verifies the new remote URL
Push the changes in your local repository to GitHub.

git push origin master
* Pushes the changes in your local repository up to the remote repository you specified as the origin

#### You can't merge with local modifications. Git protects you from losing potentially important changes.

You have three options.
1. Commit the change using

    git commit -m "My message"

2. Stash it.

Stashing acts as a stack, where you can push changes, and you pop them in reverse order.

To stash type:

git stash

Do the merge, and then pull the stash:

git stash pop

3. Discard the local changes

using git reset --hard. or git checkout -t -f remote/branch
3. a) Discard local changes for a specific file

using git checkout filename

### Merging a pull request
```bash
ambagasdowa@uruk:/var/www/pool/public_html/V41K3RMX$ git status
On branch master
Your branch is up-to-date with 'origin/master'.
nothing to commit, working tree clean

$git checkout -b cyb3r14V1rtu4L-master master
Switched to a new branch 'cyb3r14V1rtu4L-master'
$git pull https://github.com/cyb3r14V1rtu4L/V41K3RMX.git master
From https://github.com/cyb3r14V1rtu4L/V41K3RMX
 * branch            master     -> FETCH_HEAD
Updating 415159f..45939c2
 .gitignore | 25 +++++++++++++++++++++++++
$git checkout master
Switched to branch 'master'
Your branch is up-to-date with 'origin/master'.
$git merge --no-ff cyb3r14V1rtu4L-master
Merge made by the 'recursive' strategy.
 .gitignore | 25 +++++++++++++++++++++++++
 1 file changed, 25 insertions(+)
$git push origin master
Username for 'https://github.com': ambagasdowa
To https://github.com/ambagasdowa/V41K3RMX.git
   415159f..7f7b195  master -> master
```
### Merging an upstream repository into your fork
(Github version)
If you don't have push (write) access to an upstream repository, then you can pull commits from that repository into your own fork.
    Open Terminal.
    Change the current working directory to your local project.
    Check out the branch you wish to merge to. Usually, you will merge into master.
    ```bash
    git checkout master
    ```
    Pull the desired branch from the upstream repository. This method will retain the commit history without modification.
    ```bash
    git pull https://github.com/ORIGINAL_OWNER/ORIGINAL_REPOSITORY.git BRANCH_NAME
    ```
    If there are conflicts, resolve them. For more information, see "Addressing merge conflicts".
    Commit the merge.
    Review the changes and ensure they are satisfactory.
    Push the merge to your GitHub repository.
    ```bash
    git push origin master
    ```

### Updating a fork using rebase

In your local clone of your forked repository, you can add the original GitHub repository as a "remote". ("Remotes" are like nicknames for the URLs of repositories - origin is one, for example.) Then you can fetch all the branches from that upstream repository, and rebase your work to continue working on the upstream version. In terms of commands that might look like:

### Add the remote, call it "upstream":

git remote add upstream https://github.com/whoever/whatever.git

 Fetch all the branches of that remote into remote-tracking branches,
 such as upstream/master:

```bash
  git fetch upstream
```

 Make sure that you're on your master branch:

git checkout master

 Rewrite your master branch so that any commits of yours that
 aren't already in upstream/master are replayed on top of that
 other branch:

git rebase upstream/master

 If you don't want to rewrite the history of your master branch, (for example because other people may have cloned it) then you should replace the last command with git merge upstream/master. However, for making further pull requests that are as clean as possible, it's probably better to rebase.

 If you've rebased your branch onto upstream/master you may need to force the push in order to push it to your own forked repository on GitHub. You'd do that with:

```bash
git push -f origin master
```

You only need to use the -f the first time after you've rebased.

### Git tagging
Listing Your Tags
$ git tag

Creating Tags
$ git tag -a v1.4 -m "my version 1.4"

Sharing Tags
$ git push origin --tags

### Clone a branch from remote repository

The 'normal' way to get this code with git would be:

    replicate the repository to your local machine

    git clone https://github.com/dnouri/nolearn.git

    (You can find this URL on the repository's page https://github.com/dnouri/nolearn, in the 'clone URL' field.)

    enter the local repository

    cd nolearn

    check out the wanted revision

    git checkout 1659e4811e498dc1f442d8e6486d0831f85255b4

    change into the respective directory inside the repository

    cd nolearn

##### How to clone a single branch in git?

Where specifies:

git clone <url> --branch <branch> --single-branch [<folder>]


##### How do I resolve git saying “Commit your changes or stash them before you can merge”?

You can't merge with local modifications. Git protects you from losing potentially important changes.

You have three options.
1. Commit the change using

    git commit -m "My message"

2. Stash it.

Stashing acts as a stack, where you can push changes, and you pop them in reverse order.

To stash type:

git stash

Do the merge, and then pull the stash:

git stash pop

3. Discard the local changes

using git reset --hard. or git checkout -t -f remote/branch
3. a) Discard local changes for a specific file

using git checkout filename


### Another merging way


down vote

Here's a probable use-case, from the top:

You're going to pull some changes, but oops, you're not up to date:

git fetch origin
git pull origin master

From ssh://gitosis@example.com:22/projectname
 * branch            master     -> FETCH_HEAD
Updating a030c3a..ee25213
error: Entry 'filename.c' not uptodate. Cannot merge.

So you get up-to-date and try again, but have a conflict:

git add filename.c
git commit -m "made some wild and crazy changes"
git pull origin master

From ssh://gitosis@example.com:22/projectname
 * branch            master     -> FETCH_HEAD
Auto-merging filename.c
CONFLICT (content): Merge conflict in filename.c
Automatic merge failed; fix conflicts and then commit the result.

So you decide to take a look at the changes:

git mergetool

Oh me, oh my, upstream changed some things, but just to use my changes...no...their changes...

git checkout --ours filename.c
git checkout --theirs filename.c
git add filename.c
git commit -m "using theirs"

And then we try a final time

git pull origin master

From ssh://gitosis@example.com:22/projectname
 * branch            master     -> FETCH_HEAD
Already up-to-date.


Coments:

---
```
 Careful! The meaning of --ours and --theirs is reversed. --ours == the remote.
 --theirs == local. See git merge --help

 In my case, I confirm that --theirs = remote repository, --ours = my own local
 repository. It is the opposite of @mmell comments

 @mmell Only on a rebase, apparently

 Guys, "ours" and "theirs" is relative to whether or not you are merging or rebasing.
  If you're merging, then "ours" means the branch you're merging into, and "theirs" is
  the branch you're merging in. When you're rebasing, then "ours" means the commits
  you're rebasing onto, while "theirs" refers to the commits that you want to rebase
 ```
 ---


### Git Submodules


### Add a repository as submodule

```bash
  cd plugins
  git submodule add https://github.com/ambagasdowa/Paper.git
```

### Update as submodule

cd plugins and run

```bash
git submodule init
# and
git submodule update
```

OR using `--recurse-submodules`

```bash
  git clone --recurse-submodules https://github.com/youraccount/yourRepo.git
```
OR Running master checkouts
Third-party components are handled as git submodules which have to be initialized first. So aside from the regular git checkout invoking

```git
  git submodule update --init
```

or a similar command is needed, for details see Git documentation.


### remove a submodule
```bash
rm -Rf Paper/

git rm -r Paper/
```

##### One way to move forward would be to start from a fresh clone of the parent repo (without any reference to your submodule), and repeat the steps:

git submodule add -b master /path/to/myrepo.git ;
git submodule update --remote --init. –





# :fa-file-pdf: Pdf section


set the defualt viewer
```bash
mimeopen -d myfile.pdf
ambagasdowa@uruk:~$ mimeopen -d myfile.pdf
Please choose a default application for files of type application/pdf

	1) Krita  (krita_pdf)
	2) LibreOffice Draw  (libreoffice-draw)
	3) Inkscape  (inkscape)
	4) vprerex  (vprerex)
	5) PDF-Shuffler  (pdfshuffler)
	6) PDF Chain  (pdfchain)
	7) GNU Image Manipulation Program  (gimp)
	8) Other...

use application #8
use command: /usr/bin/okular
```

##### Edit pdf

when edit a pdf with gimp

import as 300 pt/in

if we have multiple pages

export as mng file and

then
convert file.mng file.pdf
enjoy


* Merge PDF files with PHP

I've done this before. I had a pdf that I generated with fpdf, and I needed to add on a variable amount of PDFs to it.

So I already had an fpdf object and page set up (http://www.fpdf.org/) And I used fpdi to import the files (http://www.setasign.de/products/pdf-php-solutions/fpdi/) FDPI is added by extending the PDF class:


```php

  class PDF extends FPDI {
     $pdffile = "Filename.pdf";
     $pagecount = $pdf->setSourceFile($pdffile);  
     for($i=0; $i<$pagecount; $i++){
         $pdf->AddPage();  
         $tplidx = $pdf->importPage($i+1, "/MediaBox");
         $pdf->useTemplate($tplidx, 10, 10, 200);
     }
  }

```

This basically makes each pdf into an image to put into your other pdf. It worked amazingly well for what I needed it for.
Not quite sure why both the accepted answer and even the FDPI homepage seem to give botched or incomplete examples. Here's mine which works and is easy to implement. As expected it requires fpdf and fpdi libraries:

   FPDF: http://www.fpdf.org/en/download.php
   FPDI: https://www.setasign.com/products/fpdi/downloads

``` php

require('fpdf.php');
require('fpdi.php');

$files = ['doc1.pdf', 'doc2.pdf', 'doc3.pdf'];

$pdf = new FPDI();

// iterate over array of files and merge
foreach ($files as $file) {
   $pageCount = $pdf->setSourceFile($file);
   for ($i = 0; $i < $pageCount; $i++) {
       $tpl = $pdf->importPage($i + 1, '/MediaBox');
       $pdf->addPage();
       $pdf->useTemplate($tpl);
   }
}

// output the pdf as a file (http://www.fpdf.org/en/doc/output.htm)
$pdf->Output('F','merged.pdf');
```

# :fa-cloud: Cloud Section

> nextcloud issues
> version 12

issues about bin row something -> edit my.cnf , add under
```ini
[mysql]
...
binlog_format='MIXED'
...
```

### Hypervisor

Extracting your `Windows` license key

sudo apt-get install acpica-tools

 ambagasdowa  ~  sudo acpidump -n MSDM
 MSDM @ 0x0000000000000000
 0000: 4D 53 44 4D 55 00 00 00 03 15 4C 45 4E 4F 56 4F  MSDMU.....LENOVO
 0010: 54 50 2D 4E 31 51 20 20 80 12 00 00 50 54 45 43  TP-N1Q  ....PTEC
 0020: 02 00 00 00 01 00 00 00 00 00 00 00 01 00 00 00  ................
 0030: 00 00 00 00 1D 00 00 00 47 4B 33 58 34 2D 4E 36  ........GK3X4-N6
 0040: 51 4D 4D 2D 34 50 51 4D 57 2D 37 52 54 57 4B 2D  QMM-4PQMW-7RTWK-
 0050: 51 56 36 36 50                                   QV66P

sudo acpidump|grep MSDM -A6|cut -c58- |xargs | tr -d " " | grep -oP '[^.]+$'




There is a great tool available for Linux called chntpw. You can get it easily on Debian/Ubuntu via:

sudo apt install chntpw

To look into the relevant registry file mount the Windows disk and open it like so:

chntpw -e /path/to/windisk/Windows/System32/config/software

Now to get the decoded DigitalProductId enter this command:

dpi \Microsoft\Windows NT\CurrentVersion\DigitalProductId

#### To install Windows Server Migration Tools on a full installation of Windows Server 2008 R2
Import-Module ServerManager
Add-WindowsFeature Migration

To export local users and groups from the source server

Add-PSSnapin Microsoft.Windows.ServerManager.Migration

Export-SmigServerSetting -User <Enabled | Disabled | All> -Group -Path <MigrationStorePath> -Verbose

Export-SmigServerSetting -User All -Group -Path c:\usr\ -Verbose

To import local users and groups to the destination server

Import-SmigServerSetting -User <Enabled | Disabled | All> -Group -Path <MigrationStorePath> -Verbose

Import-SmigServerSetting -User All -Group -Path C:\usr -Verbose

# Libre office

install backports-stretch for a newer versions

install libreoffice-gtk2
install
```bash
wget -qO- https://raw.githubusercontent.com/PapirusDevelopmentTeam/papirus-libreoffice-theme/master/install-papirus-root.sh | sh
```
more info
https://github.com/PapirusDevelopmentTeam/papirus-libreoffice-theme

for a cool theme or
install libreoffice-style-breeze


# :fa-code: Code Section

#### Installing RichFilemanager app

clone the repo

```bash
git clone http://github.com/servocoder/RichFilemanager.git
```

then cp the config files from manual
You can see 2 files in the config folder. Both should be copied and renamed as the following:

    >filemanager.config.default.json -> filemanager.config.json

Main configuration file. All scalar configuration options should be defined here. Reference.

    >filemanager.init.js.example -> filemanager.init.js

after that run in RichFilemanager dir
```bash
  composer update
```

#### Add Google repo

* add the key
```bash
wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | sudo apt-key add -
```

* then add the repo
```bash
echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list
```


#### Composer installation


### Introduction

[Composer](https://getcomposer.org/) is a popular dependency management tool
for PHP, created mainly to facilitate installation and updates for project
dependencies. It will check which other packages a specific project depends on
and install them for you, using the appropriate versions according to the
project requirements.

This tutorial will show how to install and get started with Composer on a
Debian 8 server.

## Prerequisites

For this tutorial, you will need:

  * One Debian 8 server with a non-root sudo user, as shown in [Initial Server Setup with Debian 8](https://www.digitalocean.com/community/tutorials/initial-server-setup-with-debian-8 "Initial Server Setup with Debian 8" )

## Step 1 — Installing the Dependencies

Before we download and install Composer, we need to make sure our server has
all necessary dependencies installed.

First, update the package manager cache.
```bash
  sudo apt-get update
```
Now, let's install the dependencies. We'll need `curl` in order to download
Composer and `php5-cli`, a PHP package, for installing and running it.
Composer uses `git`, a version control system, to download project
dependencies. You can install all three of these packages at once with this
command:
```bash
sudo apt-get install curl php5-cli git
```
Now that the essential dependencies are installed, let's proceed and install
Composer itself.

## Step 2 — Downloading and Installing Composer

We will follow the instructions as written in [Composer's official
documentation](https://getcomposer.org/download/) with a small modification to
install Composer globally under `/usr/local/bin`. This will allow every user
on the server to use Composer.

Download the installer to the `/tmp` directory.

```php  
php -r "copy('https://getcomposer.org/installer', '/tmp/composer-setup.php');"
```
Visit [Composer's pubkeys and signatures
page](https://composer.github.io/pubkeys.html) and copy the SHA-384 string at
the top . Then, run the following command by replacing `sha_384_string` with
the string you copied.
```php
  php -r "if (hash_file('SHA384', '/tmp/composer-setup.php') === 'sha_384_string') { echo 'Installer verified'; } else { echo 'Installer corrupt'; unlink('/tmp/composer-setup.php'); } echo PHP_EOL;"

  php -r "if (hash_file('SHA384', 'composer-setup.php') === '544e09ee996cdf60ece3804abc52599c22b1f40f4323403c44d44fdfdd586475ca9813a858088ffbc1f233e9b180f061') { echo 'Installer verified'; } else { echo 'Installer corrupt'; unlink('composer-setup.php'); } echo PHP_EOL;"

```    
This command checks the hash of the file you downloaded with the correct hash
from Composer's website. If it matches, it'll print **Installer verified**. If
it doesn't match, it'll print **Installer corrupt**, in which case you should
double check that you copied the SHA-384 string correctly.

Next, we will install Composer. To install it globally under `/usr/local/bin`,
we'll use the `--install-dir` flag; `--filename` tells the installer the name
of Composer's executable file. Here's how to do this in one command:    

```php
  sudo php /tmp/composer-setup.php --install-dir=/usr/local/bin --filename=composer
```
You'll see a message like the following:    
Output:

```php
All settings correct for using Composer
Downloading...

Composer (version 1.3.2) successfully installed to: /usr/local/bin/composer
Use it: php /usr/local/bin/composer
```

You can verify that Composer is correctly installed by checking its version.

```bash
  composer --version
```
You should see the version that was installed. At that time of this writing,
the version is:

Composer version
    Composer version 1.3.2 2017-01-27 18:23:41
Finally, you can safely remove the installer script as you no longer need it.    
```php
  rm /tmp/composer-setup.php
```
Composer is now set up and running, waiting to be used by your project. In the
next section, you'll generate the `composer.json` file, which includes the PHP
libraries that your project depends on.


##### After Composer update
Some packages has suggestions to install it do

this runs

```bash
 composer suggests | xargs -i composer require {}

```

#### Pear installation

* make a dir under named pear in home or {/usr/share/}pear
* download the file go-pear.php


  $ wget http://pear.php.net/go-pear.phar
  and run
  $ php go-pear.phar


as root for a global installation

### add webdav client support
install as root this downloads the needed libs in /usr/share/php

```bash
pear install HTTP_WebDAV_Client-1.0.2
```
---

## :fa-codepen: Javascript Section
Simple indexOf search

```javascript

      var $rows = $('#table tr');
      $('#search').keyup(function() {
          var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

          $rows.show().filter(function() {
              var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
              return !~text.indexOf(val);
          }).hide();
      });
```
Regular expression search
More advanced functionality using regular expressions will allow you to search words
in any order in the row. It will work the same if you type apple green or green apple:

```javascript

      // var $rows = $("#table tr");
      // $("#search").keyup(function() {

          // var val = "^(?=.*\\b' + $.trim($(this).val()).split(/\s+/).join('\\b)(?=.*\\b') + ').*$";
          // var reg = RegExp(val, "i");
          // var text;
          //
          // $rows.show().filter(function() {
          //     text = $(this).text().replace(/\s+/g, " ");
          //     return !reg.test(text);
          // }).hide();
      // });

```

# :fa-android: Android

### udev

Set up a device for development

Before you can start debugging on your device, there are a few things you must do:

    On the device, open the Settings app, select Developer options, and then enable USB debugging.
    Note: If you do not see Developer options, follow the instructions to enable developer options.
    Set up your system to detect your device.
        Windows: Install a USB driver for Android Debug Bridge (adb). For an installation guide and links to OEM drivers, see the Install OEM USB Drivers document.
        Mac OS X: It just works. Skip this step.
        Ubuntu Linux: Use apt-get install to install the android-tools-adb package. This gives you a community-maintained default set of udev rules for all Android devices.

        Make sure that you are in the plugdev group. If you see the following error message, adb did not find you in the plugdev group:

        error: insufficient permissions for device: udev requires plugdev group membership

        Use id to see what groups you are in. Use sudo usermod -aG plugdev $LOGNAME to add yourself to the plugdev group.

        The following example shows how to install the Android adb tools package.

        apt-get install android-tools-adb

Try this:

    Create udev rules

    sudo gedit /etc/udev/rules.d/51-android.rules

    Insert this lines, save and exit

    SUBSYSTEM=="usb", ATTR{idVendor}=="1bbb", MODE="0666", GROUP="plugdev"

    Restart udev

    sudo service udev restart

    Enable USB Debug in your phone (In Android 4.2.x and up Developer Options is hidden, to make it visible, do the following)
        Tap seven times in Build Number: Settings > About Phone > Build Number
        You will get a message saying you have enabled Developer Options or something like that, go back to Settings and you will see Developer Options in there.

    Connect phone with USB cable

    Open Terminal and type

    adb devices

I have Alcatel OneTouch Pop C7 (7041D)

List of devices attached  
6H9PY5ZPJV9HO7R4    device

##### on/off display
Works to turn on screen (when display is off) Works to turn off screen (when display is on/awake)

adb shell input keyevent KEYCODE_POWER

https://stackoverflow.com/questions/7585105/turn-on-screen-on-device

### :fa-signal: NODE JS Engine

for Install Node.js 9 in Debian:
```bash
curl -sL https://deb.nodesource.com/setup_9.x | sudo -E bash -
sudo apt-get install -y nodejs
```
Optional: install build tools

To compile and install native addons from npm you may also need to install build tools:
```bash
sudo apt-get install -y build-essential
```

### :fa-meteor: Install Meteor

```bash
curl https://install.meteor.com/ | sh
```

### debian method

MeteorJS or simply Meteor is an open-source framework based on JavaScript. It is written using Node.js and allows you to build apps for any device (web, iOS, Android, or desktop) using the same code. In this tutorial, we will show you how to deploy a simple Meteor application on a Linux VPS running Ubuntu 16.04 as an operating system.

Connect to your Linux server via SSH and install the MeteorJS framework using the command below:

```bash
sudo curl https://install.meteor.com/ | sh
```
This will install the latest official Meteor release on your Ubuntu VPS.
It will take a couple of minutes for the installation process to finish, and once it is completed you can verify that the installation is successful by checking the Meteor version:

meteor --version
This should provide you with output very similar to this one:

$ meteor --version
Meteor 1.4.3.2
If you are running the meteor command for the first time, it will take a couple of seconds for Meteor to be set up in your user’s home directory.
Now you are ready to create your first MeteorJS application. Navigate to your home directory:

```bash
cd ~
# and run the following command:
meteor create firstApp
# The application will be set up immediately. To run the application, use the following commands:
cd firstApp
meteor
# Make sure that there are no errors in the output. It should be similar to the one below:

$ meteor

[[[[[ ~/firstApp ]]]]]

=> Started proxy.
=> Started MongoDB.
=> Started your app.

=> App running at: http://localhost:3000/
# Now the application is running on port 3000 and it is accessible from the local machine only. To make it accessible using a domain name you can set up Nginx as a reverse proxy on your Meteor VPS.
```
First, install Nginx and set up a server block.
Add the following lines to the Nginx server block for your Meteor application:

```nginx
upstream meteor {
    server 127.0.0.1:3000;
}
```
```nginx
server {
    listen      80;
    server_name your_domain;

    access_log  /var/log/nginx/meteor.access.log;
    error_log   /var/log/nginx/meteor.error.log;

    proxy_buffers 16 64k;
    proxy_buffer_size 128k;

location / {
        proxy_pass  http://meteor;
        proxy_next_upstream error timeout invalid_header http_500 http_502 http_503 http_504;
        proxy_redirect off;

        proxy_set_header    Host            $host;
        proxy_set_header    X-Real-IP       $remote_addr;
        proxy_set_header    X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header    X-Forwarded-Proto https;
    }
}
```
Replace your_domain with your actual domain name. Save and close the file, then check if there are errors:

sudo nginx -t
If there are no errors, restart nginx:
```bash
sudo systemctl restart nginx.service
```
Restart your Meteor application and open your web browser. You should be able to access the Meteor application you just deployed using your domain name. If you see the welcome screen like the one below it means your Meteor application is successfully deployed.

#### Update Your npm Version

One final step for good measure is to update the version of npm. There's always a specific version of npm that ships with Node.js. That said, the release cycle of npm is not in sync with the release cycle of Node.js - as such, there's frequently a newer version of npm than the one that comes with Node.

To update your version of npm, simply run the following command:
```bash
$ sudo npm install npm --global
```

# :fa-bluetooth Bluethooth Section

Pair a blue keyboard

https://askubuntu.com/questions/701978/how-can-a-bluetooth-keyboard-that-requires-a-code-entry-be-paired-in-the-termina

You can try running bluetoothctl from the command line, make sure your device is on / ready to be discovered:

$ bluetoothctl
[NEW] Controller AA:BB:CC:DD:EE:FF device-name [default]

Any other bluetooth devices will be listed here. You'll then be inside a [bluetooth] prompt.

First, turn bluetooth power on (if your device is off):

[bluetooth]# power on
Changing power on succeeded

Then, make sure your agent is registered:

```bash
[bluetooth]# agent on
```
Agent registered

```sh
[bluetooth]# default-agent
```

Default agent request successful

Now you can scan for devices from the console:

```bash
[bluetooth]# scan on
Discovery started
[CHG] Controller AA:BB:CC:DD:EE:FF Discovering: yes
[NEW] Device FF:EE:DD:CC:BB:AA Someones Keyboard
```

You can manually pair from here as well:

```bash
[bluetooth]# pair FF:EE:DD:CC:BB:AA
Attempting to pair with FF:EE:DD:CC:BB:AA
[CHG] Device C8:E0:EB:04:52:55 Connected: yes
```

At this point, you should be prompted to enter a pin code for pairing:

```bash
Request PIN code
[agent] Enter PIN code: 12345
```

Enter a number (eg. 12345), and you will be prompted to input the same number from the device:

```bash
[Someones Keyboard]# 12345
```
You should then be notified that your keyboard has paired:
```bash
[CHG] Device FF:EE:DD:CC:BB:AA Paired: yes
```
Hopefully this works for you, was trying to solve this for a while before I found any reference to bluetoothctl





# :fa-linux: :fa-apple: :fa-windows: OS-Admin section

Linux
-----
#### Build an empty image

This is a step-by-step guide to create a custom image starting from scratch;
I'll assume the following:

    The image size should be 100 MiB
    The image partition table should be MBR
    The image should contain a single FAT32 primary partition

Creating the blank image

Create the blank image:
```bash
dd if=/dev/zero of=image.img iflag=fullblock bs=1M count=100 && sync

ubuntu@ubuntu ~/tmp % dd if=/dev/zero of=image.img iflag=fullblock bs=1M count=100 && sync
100+0 records in
100+0 records out
104857600 bytes (105 MB) copied, 0.0415825 s, 2.5 GB/s
ubuntu@ubuntu ~/tmp % tree
.
└── image.img

0 directories, 1 file
```

Mounting the blank image

List the already busy loopback devices:
```bash
losetup


ubuntu@ubuntu ~/tmp % losetup                   
NAME       SIZELIMIT OFFSET AUTOCLEAR RO BACK-FILE
/dev/loop0         0      0         0  1 /cdrom/casper/filesystem.squashfs
```

Mount the image on the first available loopback device:
```bash
sudo losetup loop1 image.img

ubuntu@ubuntu ~/tmp % sudo losetup loop1 image.img
ubuntu@ubuntu ~/tmp % losetup
NAME       SIZELIMIT OFFSET AUTOCLEAR RO BACK-FILE
/dev/loop0         0      0         0  1 /cdrom/casper/filesystem.squashfs
/dev/loop1         0      0         0  0 /home/ubuntu/tmp/image.img
```
Partitioning / formatting the blank image

Run gparted passing the loopback device as an argument:

sudo -H gparted /dev/loop1

or fdisk instead


#### Preview Handler
Windows
----
 #### No puede abrir los datos adjuntos de los archivos vinculados en Outlook: "Outlook bloqueó el acceso a los siguientes datos adjuntos potencialmente inseguros"

 ### Causa
 ---
 Este problema se produce porque, de forma predeterminada, Outlook 2010 y Outlook 2013 no permiten que se abran los datos adjuntos del archivo vinculado. Además, la actualización de seguridad de julio de 2010 realizó un cambio en Outlook 2002, Outlook 2003 y Outlook 2007 para que estos incluyan este comportamiento.

 Se puede usar una entrada de Registro para impedir que Outlook bloquee los datos adjuntos de archivos vinculados de modo que éstos se puedan abrir directamente. Sin embargo, no se recomienda usar esta entrada del Registro ya que de esta forma se reducirá la seguridad de Outlook y se podría permitir el acceso a los datos adjuntos malintencionados.

 Para configurar la entrada de Registro AllowAttachByRef, agregue un valor DWORD denominado AllowAttachByRef que tenga el valor de 1.

 Para agregar esta entrada de Registro, siga estos pasos:

 Haga clic en Inicio y en Ejecutar, en el cuadro Abrir escriba regedit y luego haga clic en Aceptar.
 Busque una de las siguientes subclaves del Registro y haga clic en ella:

```init
         Outlook 2013 (versión 15,0)
         HKEY_CURRENT_USER\Software\Microsoft\Office\15.0\Outlook\Security O bien:HKEY_CURRENT_USER\Software\Policies\Microsoft\Office\15.0\Outlook\Security
         Outlook 2010 (versión 14.0)
         HKEY_CURRENT_USER\Software\Microsoft\Office\14.0\Outlook\Security
         O bien:HKEY_CURRENT_USER\Software\Policies\Microsoft\Office\14.0\Outlook\Security
         Outlook 2007 (versión 12.0)
         HKEY_CURRENT_USER\Software\Microsoft\Office\12.0\Outlook\Security
         O bien:HKEY_CURRENT_USER\Software\Policies\Microsoft\Office\12.0\Outlook\Security
         Outlook 2003 (versión 11.0)
         HKEY_CURRENT_USER\Software\Microsoft\Office\11.0\Outlook\Security
         O bien: HKEY_CURRENT_USER\Software\Policies\Microsoft\Office\11.0\Outlook\Security
         Outlook 2002 (versión 10.0)
         HKEY_CURRENT_USER\Software\Microsoft\Office\10.0\Outlook\Security
         O bien:

         HKEY_CURRENT_USER\Software\Policies\Microsoft\Office\10.0\Outlook\Security
```

 En el menú Edición, seleccione Nuevo y haga clic en Valor DWORD.
 Escriba AllowAttachByRef como nombre del valor DWORD y luego presione ENTRAR.
 Haga clic con el botón derecho en AllowAttachByRef y luego haga clic en Modificar.
 En el cuadro Información del valor, escriba 1 y haga clic en Aceptar.
 Salga del Editor del Registro y reinicie el equipo.

#### Kill task in windows

taskkill.exe /F /IM iexplore.exe /T


#### Connect to samba NetWork

Connect Network Drive

To map a network drive from windows command line:

    Click Start, and then click Run .
    In the Open box, type cmd to open command line window.
    Type the following, replacing Z: with drive letter you want to assign to the shared resource:

    net use Z: \\computer_name\share_name /PERSISTENT:YES

Disconnect Network Drive

To disconnect a mapped drive:

    Open command line window.
    Type the following, replacing X: with drive letter of the shared resource:

    net use  Z: /delete    

### remove packages anoing
BTW the article you linked deals with exit status 2 when trying to remove a package. In this situation, deleting the package record from /var/lib/dpkg/status would certainly help. But even then instead of editing the file manually, I'd try to locate and remove the record with sed.

The following should give the same output as dpkg -s package_name:
Code:
```bash
sed -n '/^Package: *package_name$/,/^$/p' /var/lib/dpkg/status
```

If it does, you can delete the record with
Code:

```bash
sudo sed -i '/^Package: *package_name$/,/^$/d' /var/lib/dpkg/status
```

#### Install telegram-cli

Instead of disabling SSL, another option is to use Arch's patch:

$ git clone --recursive https://github.com/vysheng/tg.git
$ cd tg
$ wget -O openssl.patch 'https://aur.archlinux.org/cgit/aur.git/plain/telegram-cli-git.patch?h=telegram-cli-git'
$ patch -p1 < openssl.patch
$ ./configure && make


#### Mod Firefox Quantum
Chosen Solution

userChrome.css and userContent.css with CSS code. I currently use this on Developer Edition and Nightly.  You need to create both .css files in a chrome folder inside your profile folder. Go to about:support --> Profile Folder --> Open Folder --> Create new folder named chrome, inside, create userContent.css and userChrome.css

Put the code into their respective files and restart Firefox.

userContent.css: https://pastebin.com/5F8uDRem
userChrome.css: https://pastebin.com/QPSn3c4V


about:support

#### Mod Chromium/Chrome

about:flags


#### Rename Files


```bash

 # for x in *.html ; do mv "$x" "${x%.html}.php" ;

```

#### build debian isos with jigdo

```bash
apt install jigdo-lite

#download template and jigdo files
#then

for i in $(ls *.jigdo);do jigdo-lite --noask $i ; done

```

#### Install python

You can install Python-3.6 on Debian 8 as follows:

wget https://www.python.org/ftp/python/3.6.3/Python-3.6.3.tgz
tar xvf Python-3.6.3.tgz
cd Python-3.6.3
./configure --enable-optimizations
make -j8
sudo make altinstall
python3.6

It is recommended to use make altinstall according to the official website.

If you want pip to be included, you need to add --with-ensurepip=install to your configure call. For more details see ./configure --help.

    Warning: make install can overwrite or masquerade the python binary. make altinstall is therefore recommended instead of make install since it only installs exec_prefix/bin/pythonversion.

Common build problems

Some packages need to be installed to avoid some known problems

sudo apt-get install -y make build-essential libssl-dev zlib1g-dev   
sudo apt-get install -y libbz2-dev libreadline-dev libsqlite3-dev wget curl llvm
sudo apt-get install -y libncurses5-dev  libncursesw5-dev xz-utils tk-dev

Update

You can download the latest python-x.y.z.tar.gz from here.

To set a default python version and easily switch between them , you need to update your update-alternatives with the multiple python version.

Let's say you have installed the python3.7 on debian stretch , use the command whereis python to locate the binary (path*/bin/python). e,g:

/usr/local/bin/python3.7
/usr/bin/python2.7
/usr/bin/python3.5

Add the python versions:

update-alternatives --install /usr/bin/python python /usr/local/bin/python3.7 50
update-alternatives --install /usr/bin/python python /usr/bin/python2.7 40
update-alternatives --install /usr/bin/python python /usr/bin/python3.5 30

The python3.7 with the 50 priority is now your default python , the python -V will print:

Python 3.7.0b2

To switch between them, use:

update-alternatives --config python

Sample output:

There are 3 choices for the alternative python (providing /usr/bin/python).

  Selection    Path                      Priority   Status
------------------------------------------------------------
* 0            /usr/local/bin/python3.7   50        auto mode
  1            /usr/bin/python2.7         40        manual mode
  2            /usr/bin/python3.5         30        manual mode
  3            /usr/local/bin/python3.7   50        manual mode

Press <enter> to keep the current choice[*], or type selection number:*

### ssh

Offending ECDSA key in /home/ambagasdowa/.ssh/known_hosts:2
  remove with:
  ssh-keygen -f "/home/ambagasdowa/.ssh/known_hosts" -R 192.168.20.215
RSA host key for 192.168.20.215 has changed and you have requested strict checking.
Host key verification failed.

### Xorg

the default path of xorg.conf

 /usr/share/X11/xorg.conf.d

### :fa-firefox:
disable web autoplay in firefox
set to true this options in about:config
```html
  media.autoplay.enabled
  media.block-autoplay-until-in-foreground
```


# :fa-terminal: Notes Section

####  ADD USER
sudo useradd -m -c "The Allmigthy" ambagasdowa -s /bin/bash

####  Convert XPS to PDF on Linux and Mac

Add the xps2pdf.sh contents to your bashrc file. If you don't know what that means, then run the following:

curl -fsSL https://gist.githubusercontent.com/balupton/7f15f6627d90426f12b24a12a4ac5975/raw/xps2pdf.sh | bash

Use like so:

# Convert a particular xps file
xps2pdf thefile.xps

# Convert all xps files in the current working directory
xps2pdf \*.xps

It will create the pdf files with the same creation time as the original xps files.


#### change the keyboard layout

in X

```bash
setxkbmap us
```
on console

```bash
loadkeys us
```

some references X
```bash
$xmodmap -pm
xmodmap:  up to 4 keys per modifier, (keycodes in parentheses):

shift       Shift_L (0x32),  Shift_R (0x3e)
lock        Caps_Lock (0x42)
control     Control_L (0x25),  Control_R (0x69)
mod1        Alt_L (0x40),  Alt_R (0x6c),  Meta_L (0xcd)
mod2        Num_Lock (0x4d)
mod3      
mod4        Super_L (0x85),  Super_R (0x86),  Super_L (0xce),  Hyper_L (0xcf)
mod5        ISO_Level3_Shift (0x5c),  Mode_switch (0xcb)
```


#### monitor off
El objetivo en cuestión para configurar ese tema es logind.conf y está en
```bash  
     /etc/systemd
```
No se si es igual en todas las distros o cambia entre unas y otras.
```bash  
    sudo nano /etc/systemd/logind.conf
```
En este archivo aparecen unas opciones mas que interesantes, no estoy seguro
al 100% pero creo que se puede aplicar la configuración adecuada para
cualquier caso editando este archivo, a mi me aparece lo siguiente:
```ini
    [Login]
    #NAutoVTs=6
    #ReserveVT=6
    #KillUserProcesses=no
    #KillOnlyUsers=
    #KillExcludeUsers=root
    #InhibitDelayMaxSec=5
    #HandlePowerKey=poweroff
    #HandleSuspendKey=suspend
    #HandleHibernateKey=hibernate
    #HandleLidSwitch=suspend
    #HandleLidSwitchDocked=ignore
    #PowerKeyIgnoreInhibited=no
    #SuspendKeyIgnoreInhibited=no
    #HibernateKeyIgnoreInhibited=no
    #LidSwitchIgnoreInhibited=yes
    #HoldoffTimeoutSec=30s
    #IdleAction=ignore
    #IdleActionSec=30min
    #RuntimeDirectorySize=10%
    #RemoveIPC=yes
```
Descomentando las linea que queramos usar y cambiándole el atributo adecuado
que nos interese se consigue la configuración deseada.  

En mi caso y a modo de ejemplo, para deshabilitar el interruptor usado en el
cierre de la pantalla de un portátil que provoca la suspensión del sistema y o
la hibernación del servidor, incluso provocaba el cierre de la sesión ssh de
acceso remoto.

```ini
    HandleSuspendKey=ignore
    HandleHibernateKey=ignore
    HandleLidSwitch=ignore
```    

Guardamos los cambios, reiniciamos el sistema operativo y comprobamos el
resultado.


#### wifi on tp470

cd /lib/firmware

Code: Select all

sudo wget https://git.kernel.org/pub/scm/linux/kernel/git/firmware/linux-firmware.git/plain/iwlwifi-8265-22.ucode


#### speedometer
speedometer -l  -r eth0  -t eth0 -m $(( 1024 * 1024 * 3 / 2 ))

##### Using Expect and Bash
Example 1
```bash
/usr/bin/expect<<EOF
spawn sudo xcodebuild -license              
expect {
    "*License.rtf" {
        send "\r";
    }
    timeout {
        send_user "\nExpect failed first expect\n";
        exit 1;
    }
}
expect {
    "*By typing 'agree' you are agreeing" {
        send "agree\r";
        send_error "\nUser agreed to EULA\n";
     }
     "*Press 'space' for more, or 'q' to quit*" {
         send "q";
         exp_continue;
     }
     timeout {
         send_error "\nExpect failed second expect\n";
         exit 1;
     }
}
EOF
```
Example 2
If you want to automate only a part of your script you can call expect inside test.sh like so :
```bash
   #!/bin/sh

   echo -n Enter User Id:
   read userid
   echo -n "Enter Password for remote user:"
   read -s password
   hostname=`hostname`

   expect -c '
   enter code here
   spawn ssh ${userid}@'"$hostname"'
   expect "Password: "
   send '"$password\r"'
   expect "$ "
   send "pbrun su - tibco\r"
   expect "$ "
   send "exit\r"
   expect "$ "
   send "pbrun bash\r"
   expect "$ "
   send "ps -ef |grep apache\r"
   expect "$ "
   send "exit\r"
    '
```

To access variables set from outside the expect -c you have to use single and double quotes like so: '"$var"'

note for integrabax storage server

in integradev go to /var/www/nextcloud/gstcloud/

then run as sudo

```bash
sudo mount.nfs -vv integrabox:/media/storage/shared/ data/
```


##### set output modes
xrandr -> view avaliable modes
```bash
Screen 0: minimum 320 x 200, current 1366 x 1024, maximum 8192 x 8192
eDP-1 connected 1366x768+0+0 (normal left inverted right x axis y axis) 309mm x 173mm
   1366x768      60.06*+
   1360x768      59.80    59.96  
   1024x768      60.04    60.00  
VGA-1 connected primary 1280x1024+0+0 (normal left inverted right x axis y axis) 419mm x 262mm
  1440x900      59.89 +  74.98  
  1280x1024     75.02*   70.00    60.02  
  1280x800      59.81  
  1152x864      75.00  
  1024x768      75.03    70.07    60.00  
```
then:
xrandr --output VGA-1 --left-of eDP-1
xrandr --output VGA-1 --mode 1440x900

## extract Extension and basename
extract the Extension
```bash
${basename##*.}
```
and for extract the basename

```bash
${basename%.*}
```

## How to decode AAC (.m4a) audio files into WAV?

codecs conversion formats

```bash
for f in *.m4a; do avconv -i "$f" "${f/%m4a/wav}"; done
```

## search code with find

##### Find a pattern inside of several files and extract that file to another dir with his dir structure
find in code example
```bash
find OperacionesPruebastbk/ -type f -iname *.aspx.vb -print0 | xargs -0 grep --color Operador
```

```bash
find ./ -type f -print0 | xargs -0 grep --color RegistroPatronal=\"E6480571109\" | grep -v src | awk -F: '{print $1}' | uniq | grep --color 2016 | xargs cp -v -r --parents --target-directory=/disk/mercenary/token/
```

 firts find files with pattern
 second clean output and print firts column that have the path of the file
 third select only needed files in this case filter by year
 last copy the file to another path
 done

##### Find inside in a pdf
```bash
find /path -name '*.pdf' -exec sh -c 'pdftotext "{}" - | grep --with-filename --label="{}" --color "your pattern"' \;
```
and copy to path

```bash
find ./ -name '*.pdf' -exec sh -c 'pdftotext "{}" - | grep --with-filename --label="{}" --color "yout pattern"' \; | awk -F: '{print $1}' | xargs cp -vr --parents --target-directory=/your/path/
```

The "-" is necessary to have pdftotext output to stdout, not to files. The --with-filename and --label= options will put the file name in the output
of grep. The optional --color flag is nice and tells grep to output using colors on the terminal.
(In Ubuntu, pdftotext is provided by the package xpdf-utils or poppler-utils.)
This method, using pdftotext and grep, has an advantage over pdfgrep if you want to use features of GNU grep that pdfgrep doesn't support.
Note: pdfgrep-1.3.x supports -C option for printing line of context.


substring and drop extension examples
file backupNom-20170531.7z
```bash

ls -1 *.7z | tr '\n' '\0' | xargs -0 -n 1 basename | cut -d'-' -f 2
$ 20170531.7z

ls -1 *.7z | tr '\n' '\0' | xargs -0 -n 1 basename | cut -d'-' -f 2 | cut -f 1 -d '.'
$ 20170631

# extract with pass examples

for i in $(ls -1); do pass=$(echo $i | tr '\n' '\0' | xargs -0 -n 1 basename | cut -d'-' -f 2 | cut -f 1 -d '.') ; 7z x -p$pass -y -aoa -o/home/ambagasdowa/pdfsave/extract/ $i ; done;


```

#### Get the major size files on top

```bash
    du -h --summarize --total * | sort -rh

# OR for hidden files

    du -h --total --max-depth=1 | sort -rh | less

```


#### list files in natural order

ls -1v

#### convert multiple image in one pdf
files are 1 to 95 img

img2pdf --pagesize letter page_{1..95}.jpg -o Emmerick_fechas_jesus.pdf

#### glx issues
Thank you, friend!
Your solution helped me in such problem:

glxinfo | grep -i "OpenGL renderer"

# glxinfo
# glxgears
# google-earth
-- all of them gave "Xlib: extension GLX missing on display :0.0" error report...

# lspci
00:02.0 VGA compatible controller: Intel Corporation 4 Series Chipset Integrated Graphics Controller (rev 03)

After, by yoyr advice,
# sudo nvidia-settings --uninstall
# sudo apt-get install --reinstall xserver-xorg-video-intel libgl1-mesa-glx libgl1-mesa-dri xserver-xorg-core
# sudo dpkg-reconfigure xserver-xorg
and reboot
the problem has gone!
Thank you!

#### Update initrams
sudo update-initramfs -u

#### fix grub
1: Bajarte la ISO de Boot Repair y quemarla en USB

Te la puedes descargar desde este link:

https://sourceforge.net/projects/boot-repair-cd/  

Introduce este comando para descargar e instalar el usb-creator-gtk:

sudo apt-get install usb-creator-gtk

Una vez usb-creator está instalado en nuestro sistema:

    Insertar un dispositivo USB
    Ejecutar usb-creator.
    Seleccionar el archivo \*.iso y el dispositivo USB destino.

2: Usar un LiveUSB de Ubuntu e instalar en él BootRepair (es temporal ya que al reiniciar se dejara de usar el liveUSB)

Nota: Si pudieses entrar en tu sistema cargando manualmente grub, podrías usar este métido directamente en tu sistema, no en un LiveUSB.

sudo add-apt-repository ppa:yannubuntu/boot-repair
sudo apt-get update
sudo apt-get install -y boot-repair
boot-repair


3: Usar un LiveUSB de Ubuntu y hacerlo a la vieja usanza, a mano

Tras arrancar el LiveUSB, necesitamos localizar las particiones de los distintos discos duros:

sudo fdisk -l


Debemos montar la partición en la que tengamos ubuntu , que en la mayoría de los casos esta partición será sda1 o sda2. Vamos a seguir suponiendo que es "sda" y no "sdb". Ejecuta este comando pero cambiando X por el número de tu partición.

sudo mount /dev/sdaX /mnt

Ahora, monta el resto de los dispositivos:

sudo mount --bind /dev /mnt/dev
sudo mount --bind /dev/pts /mnt/dev/pts
sudo mount --bind /proc /mnt/proc
sudo mount --bind /sys /mnt/sys


Ejecuta el comando chroot de forma que accedemos como root al sistema de archivos de nuestro antiguo Ubuntu:

sudo chroot /mnt


Ahora instalamos Grub en el MBR con:

grub-install --boot-directory=/boot/ --recheck /dev/sda


(Aquí ya no hay que poner el número solo el disco que arranca los sistemas operativos, que como decíamos antes en este ejemplo usamos sda)

Reiniciamos y cuando vuelva a arrancar ubuntu (no el del LiveCD), podemos ajustar en el menú del GRUB manualmente editando la configuración si falta algún SO, o hacerlo automáticamente con el siguiente comando:

sudo update-grub2


4: En Arch o Antergos

Instalamos el efibootmgr:

pacman -S efibootmgr

Y una vez instalado vamos a por el grub:

sudo grub-install /dev/sda

sudo grub-mkconfig -o /boot/grub/grub.cfg

Reiniciar

#### Mod Grub

Configure GRUB2 Boot Loader Settings In Ubuntu 16.04
by sk · Published April 11, 2016 · Updated April 11, 2017
6-7 minutes

As you probably know, GRUB2 is default boot loader for most Linux operating systems. GRUB stands for GRand Unified Bootloader. GRUB boot loader is the first program that runs when the computer starts. It is responsible for loading and transferring control to the operating system Kernel. Then, the Kernel takes charge, and initializes the rest of the operating system.

In this tutorial, we will be discussing about configuring some important GRUB2 Boot Loader’s settings in Ubuntu 16.04 LTS desktop. I tested this guide in Ubuntu 16.04 LTS desktop, however these instructions might work on all Linux operating systems that uses GRUB2 boot loader.
Configure GRUB2 Boot Loader settings

Warning: The default configuration file for GRUB2 is /boot/grub/grub.cfg. You shouldn’t edit or modify this file, unless you are much familiar with GRUB2. This is the main file to boot into the Linux OS. If you do anything wrong with this file, then you will be surely end up with broken system. So, Don’t touch this file!

All settings related to the GRUB2 will be stored in /etc/default/grub file. Whatever the changes you made in this file will be reflected to the GRUB2.

Make a backup of /etc/default/grub file before making any changes.

sudo cp /etc/default/grub /etc/default/grub.bak

Let us see the main options in the GRUB boot loader.

The typical grub will look like below.

cat /etc/default/grub

Sample output:
```config
# If you change this file, run 'update-grub' afterwards to update
# /boot/grub/grub.cfg.
# For full documentation of the options in this file, see:
# info -f grub -n 'Simple configuration'

GRUB_DEFAULT=0
GRUB_HIDDEN_TIMEOUT=0
GRUB_HIDDEN_TIMEOUT_QUIET=true
GRUB_TIMEOUT=10
GRUB_DISTRIBUTOR=`lsb_release -i -s 2> /dev/null || echo Debian`
GRUB_CMDLINE_LINUX_DEFAULT="quiet splash"
GRUB_CMDLINE_LINUX=""

# Uncomment to enable BadRAM filtering, modify to suit your needs
# This works with Linux (no patch required) and with any kernel that obtains
# the memory map information from GRUB (GNU Mach, kernel of FreeBSD ...)
#GRUB_BADRAM="0x01234567,0xfefefefe,0x89abcdef,0xefefefef"

# Uncomment to disable graphical terminal (grub-pc only)
#GRUB_TERMINAL=console

# The resolution used on graphical terminal
# note that you can use only modes which your graphic card supports via VBE
# you can see them in real GRUB with the command `vbeinfo'
#GRUB_GFXMODE=640x480

# Uncomment if you don't want GRUB to pass "root=UUID=xxx" parameter to Linux
#GRUB_DISABLE_LINUX_UUID=true

# Uncomment to disable generation of recovery mode menu entries
#GRUB_DISABLE_RECOVERY="true"

# Uncomment to get a beep at grub start
#GRUB_INIT_TUNE="480 440 1"
```

Whenever you made a change in this file, you must run the following command to apply the changes to the GRUB2.

sudo update-grub

Let us do three important tweaks in the GRUB2 boot loader.
1. Select default OS (GRUB_DEFAULT)

We can select the default OS to boot using this option. If you set the value as “0”, the first operating system in the GRUB boot menu entry will boot. If you set it as “1”, the second OS will boot, and so on.

Also, if you have more than one OS in your system, you can boot the last operating system using the value GRUB_DEFAULT=saved. Whenever you reboot the system, the last operating system will start boot. Please note that you should add a line GRUB_SAVEDEFAULT=true to make this trick work.

You can also specify the name of the operating system’s entry to boot a particular OS. For example, if there is an entry called “Lubuntu 14.04 LTS” in the BOOT menu, you could use GRUB_DEFAULT=”Lubuntu 14.04 LTS” to boot Lubuntu by default. Be mindful that you should specify the value within the quotes.
2. Set OS timeout (GRUB_TIMEOUT)

By default, the selected entry from the boot menu will start to boot in 10 seconds.

You can increase or decrease this timeout setting. If the value is “0”, the default OS will immediately start to boot. If the value is “5” , the boot menu will appear for 5 seconds, so that you can select which OS you want to load when the system starts.

3. Change GRUB background image

To change the GRUB background image, you need to copy your preferred image to /boot/grub/ location.

sudo cp ostechnix.png /boot/grub/

Replace the image path with your own. You can use JPG/JPEG format images as well. But GRUB supports only 256 color JPG/JPEG image formats only. So, it is better to use PNG format images.

Once you made the necessary changes in the GRUB file, Save and close it.

To apply the changes, you must run the following command:

sudo update-grub

You should see the following output:

Generating grub configuration file ...
Found background image: ostechnix.png
Found linux image: /boot/vmlinuz-4.4.0-15-generic
Found initrd image: /boot/initrd.img-4.4.0-15-generic
Found linux image: /boot/vmlinuz-4.2.0-34-generic
Found initrd image: /boot/initrd.img-4.2.0-34-generic
Found memtest86+ image: /boot/memtest86+.elf
Found memtest86+ image: /boot/memtest86+.bin
done

Reboot and check whether the changes are working or not.

Please be mindful that you shouldn’t edit or modify GRUB2 settings in mission critical or production systems. I recommend you to test these settings in any virtual machine first, and then apply to the production systems.

That’s all folks. I will be here soon with another Interesting article. If you find this guide helpful, please share it on your social and professional networks.

## ls hdd devices by uuid and mount it

make a dir source ex: */media/externalx*

```bash
ambagasdowa@uruk:~/Github$ sudo lsblk --output NAME,FSTYPE,LABEL,UUID,MODE
NAME   FSTYPE LABEL       UUID                                 MODE
sda                                                            brw-rw----
|-sda1 swap               2d2f3618-a26b-4719-8e70-8d4ef3a88d0f brw-rw----
|-sda2 ext4               127a8f38-e25e-4dae-ba89-b195af71df70 brw-rw----
|-sda3                                                         brw-rw----
`-sda5 ext4               d5abb0c9-3205-4bf4-bf6e-629e95c3af1f brw-rw----
sdb                                                            brw-rw----
|-sdb1 swap               fc532612-ead2-4b82-8ac3-72bc1b9ca39f brw-rw----
|-sdb2                                                         brw-rw----
|-sdb5 ext4               837dd734-eeba-48a9-a001-e6711c2032a1 brw-rw----
`-sdb6 ext4               e3ca1ebb-56e5-486c-970d-38be0ef5034d brw-rw----
sdc                                                            brw-rw----
`-sdc1 vfat   MYLINUXLIVE D85A-828F                            brw-rw----
sr0                                                            brw-rw----
```
in fstab add

```config
#mount external hdd
UUID=837dd734-eeba-48a9-a001-e6711c2032a1 /media/externalx auto defaults,noauto 0 1
UUID=e3ca1ebb-56e5-486c-970d-38be0ef5034d /media/externaly auto defaults,noauto 0 1
```

  ## locale

perl: warning: Setting locale failed.

rewrite with
> sudo locale-gen en_US en_US.UTF-8

or reconfigure the package

> sudo dpkg-reconfigure locales

some kind of fix in enviorement

``` bash
sudo -i
locale
export LANGUAGE=en_US.UTF-8; export LANG=en_US.UTF-8; export LC_ALL=en_US.UTF-8; locale-gen en_US.UTF-8
dpkg-reconfigure locales
reboot

```

### OpenLuis

```vb

Imports System.Data.OleDb         ' Required'
Imports System.Data.SqlClient

'Partial Class pridesp01_pre_i_despasignarpedidos
'    Inherits System.Web.UI.Page

'#Region "Propiedades"
'......'
'Comes from login for sqlConnection'
' Public sqlConnection As Data.OleDb.OleDbConnection
'Comes from login for sqlConnection'

' NOTE Add Check if the "Licencia  de Conducir " is valid
Public Sub driverLicense(ByVal intOperador As Integer)
' -- =========================================================================================== --
' --  Procedimiento de conexion a la base de datos usando la definicion en web.config'
' -- =========================================================================================== --
    Dim connectionString As String
    Dim connection As OleDbConnection
    connectionString = ConfigurationManager.AppSettings("strConn").ToString
    connection = New OleDbConnection(connectionString)
    Dim folio,vence,cdays,id_operador,namae As String
    id_operador = intOperador
    Try
      Dim sqlcmd As OleDbCommand = connection.CreateCommand
      Dim rdr2 As OleDbDataReader

      sqlcmd.CommandText = "select nombre,folio_licencia,fecha_venclicencia,rfc from personal_personal where id_personal = " & id_operador
        connection.Open()
      ' Me.txtgetConnection.Text = "Connected to OLEDB Database  !!"
      rdr2 = sqlcmd.ExecuteReader
          While rdr2.Read()
              ' Response.Write(rdr2.Item("folio_licencia"))
              ' Response.Write(rdr2.Item("fecha_venclicencia"))
              namae = rdr2.Item("nombre")
              folio = rdr2.Item("folio_licencia")
              vence = rdr2.Item("fecha_venclicencia")
          End While
      connection.Close()

      Me.lblError.Text = "ADVERTENCIA : Quedan x dias Al Op. " & namae & " con numero " & id_operador & " para el vencimiento => Lic " & folio & " Vence => " & vence
      Me.lblError.Visible = True

    Catch ex As Exception
      ' Me.txtgetConnection.Text = "Could not connect to database " & ex.ToString
    End Try

' -- =========================================================================================== --

End Sub

Another Approach

' NOTE Add Check if the "Licencia  de Conducir " is valid
Public Shared Function driverLicense(ByVal intOperador As Integer) as String
' -- =========================================================================================== --
' --  Procedimiento de conexion a la base de datos usando la definicion en web.config'
' -- =========================================================================================== --
    Dim connectionString As String
    Dim connection As OleDbConnection
    connectionString = ConfigurationManager.AppSettings("strConn").ToString
    connection = New OleDbConnection(connectionString)
    Dim folio,vence,cdays,id_operador,namae,validations As String
    id_operador = intOperador
    Try
      Dim sqlcmd As OleDbCommand = connection.CreateCommand
      Dim rdr2 As OleDbDataReader

      sqlcmd.CommandText = "select nombre,folio_licencia,fecha_venclicencia,rfc from personal_personal where id_personal = " & id_operador
        connection.Open()
      ' Me.txtgetConnection.Text = "Connected to OLEDB Database  !!"
      rdr2 = sqlcmd.ExecuteReader
          While rdr2.Read()
              ' Response.Write(rdr2.Item("folio_licencia"))
              ' Response.Write(rdr2.Item("fecha_venclicencia"))
              namae = rdr2.Item("nombre")
              folio = rdr2.Item("folio_licencia")
              vence = rdr2.Item("fecha_venclicencia")
          End While
      connection.Close()

      validations = "ADVERTENCIA : Quedan x dias Al Op. " & namae & " con numero " & id_operador & " para el vencimiento => Lic " & folio & " Vence => " & vence

      Return validations
      ' Me.lblError.Text = validations
      ' Me.lblError.Visible = True
    Catch ex As Exception
      ' Me.txtgetConnection.Text = "Could not connect to database " & ex.ToString
    End Try
' -- =========================================================================================== --
End Function

```

``` asp
<tr>
  <td>
      Validation
  </td>
  <td colspan="2">
      <asp:TextBox ID="txtValidaLic" TabIndex="-1" runat="server" CssClass="desc" ReadOnly="True"
        BackColor="Transparent" Height="20px">
      </asp:TextBox>
  </td>
</tr>
```

# SQL

* Sql notes

#### MariaDB Connect Engine

## Some Connect Engine Notes
Example: Connect MariaDB on Linux to Microsoft SQL Server

This example uses the tabname option to work around a difference between MariaDB and SQL Server.
 We want to retrieve some AdventureWorks data stored in the Person.Address table. However,
 MariaDB does not have the idea of a table schema, and so we will change the name of the table to "PersonAddress" in MariaDB.
 We specify the actual table name with the tabname, so the SQL Server ODBC driver can pass on the table name that SQL Server recognises.

```bash
$ /opt/mariadb/bin/mysql --socket=/opt/mariadb-data/mariadb.sock
MariaDB [(none)]> CREATE DATABASE MSSQL;
MariaDB [(none)]> USE MSSQL;
MariaDB [MSSQL]> INSTALL SONAME 'ha_connect';
MariaDB [MSSQL]> CREATE TABLE PersonAddress engine=connect
                                            table_type=ODBC
                                            tabname='Person.Address'
                                            Connection='DSN=SQLSERVER_ADVENTUREWORKS;';
ERROR 1105 (HY000): Unsupported SQL type -11
MariaDB [MSSQL]> \! grep -- -11 /usr/local/easysoft/unixODBC/include/sqlext.h
#define SQL_GUID				(-11)
MariaDB [MSSQL]> CREATE TABLE PersonAddress (  AddressID int,  
                                                AddressLine1 varchar(60),  
                                                AddressLine2 varchar(60),
                                                City varchar(30),
                                                StateProvinceID int,
                                                PostalCode varchar(15),
                                                rowguid varchar(64),
                                                ModifiedDate datetime )
                                 engine=connect
                                 table_type=ODBC
                                 tabname='Person.Address'
                                 Connection='DSN=SQLSERVER_SAMPLE;';
MariaDB [MSSQL]> SELECT City FROM PersonAddress WHERE AddressID = 32521;
+-----------+
| City      |
+-----------+
| Sammamish |
+-----------+
```


Because there is no direct equivalent for the SQL Server data type uniqueidentifier.
We have to map this type in the rowguid column to a MariaDB VARCHAR type.
Even though this is the only problematic column, we need to include the others in the CREATE TABLE statement.
Otherwise, the table would only contain the rowguid column.

#### unix_socket error mariadb


The "unix_socket" has been called by mysql authentication process (maybe related to a partial migration of database to mariadb, now removed). To get all stuff back working go su:

sudo su

then follow:
```bash
/etc/init.d/mysql stop
mysqld_safe --skip-grant-tables &
mysql -uroot
```
This will completely stop mysql, bypass user authentication (no password needed) and connect to mysql with user "root".
Now, in mysql console, go using mysql administrative db:
```bash
use mysql;
```
To reset root password to mynewpassword (change it at your wish), just to be sure of it:
```sql
update user set password=PASSWORD("mynewpassword") where User='root';
```
And this one will overwrite authentication method, remove the unix_socket request (and everything else), restoring a normal and working password method:
```sql
update user set plugin="mysql_native_password";
```
Exit mysql console:
```bash
quit;
```
Stop and start everything related to mysql:
```bash
/etc/init.d/mysql stop
kill -9 $(pgrep mysql)
/etc/init.d/mysql start
```
Don\'t forget to exit the su mode.
Now mySQL server is up and running. You can login it with root:
```bash
mysql -u root -p
```
or whatever you wish. Password usage is operative.
That\'s it.


NetWork scan

sudo nmap -PR -sU --script nbstat.nse -p 137,445 192.168.20.0/24

sudo netdiscover -r 192.168.20.0/24 -i enp0s31f6

nast


#### HackThisSite

You have 60 seconds to compromise a Linux machine given the root password (No installing software or ssh) What do you do?

Strangely, it seems for most people compromise means destroy. For me it’s not. Compromise means take over or escalate privilege. If you have the root pw (for a time) it’s meaning keep that privilege for undefined time. You *must go stealth* immediately as much as possible and return later.

In 60 seconds you can do the following according to the circumstances:

    Log in (10 sec)
    Create another uid 0 user. Very easy, still effective. Create (or select existing known) user and edit it’s uid to 0 in /etc/passwd. You will be root without being called root. (10sec)
    visudo (if sudo is installed). For example, you can give NOPASSWD sudo right for www-data or httpd user and compromise the machine later over it’s web interface. Simple, but easy to spot. It’s ok for short time frame. (10 sec)
    Create suid script or simply suid sh or cat (or anything that can write disk or spawn shell). You can hide it anywhere. Very hard to spot without explicit full search (eg. find) or active tripwires. (10 sec)
    Start remote backdoor in the background. For example: nc -l -p 1234 | /bin/bash & disown (10 sec) Optionally
    punch a hole in the firewall: iptables -I INPUT -p tcp —dport 1234 -j ACCEPT (+10 sec)
    remove bash history if you have time (history -c). Many distros won’t include command in history if you start them with space. (5 sec)
    Clear screen (ctrl+L) and logout (ctrl+d) (2 sec)
    Lean back and smile innocently ;)

EDIT: one more devilish method came into my mind. Edit PAM rules. Locate the login rules in /etc/pam.d/ (most possibly system-auth or something). Change keyword “required“ to “sufficient” in the line starting with auth and containing pam_unix.so. Now you essentially turned off the password authentication *without* turning off the password prompt. You can just login as any user (eg root) with any password. *Very* hard to detect. No background process, no open ports, no suspicious suid bits (which is checked regularly). The only way to catch it if someone knowingly write a wrong password (not counting full filesystem change audit which is requirement in highly secure environment of course).


#### The Seven Sins against TSQL Performance

There are seven common antipatterns in TSQL coding that make code perform badly, and three good habits which will generally ensure that your code runs fast. If you learn nothing else from this list of great advice from Grant, just keep in mind that you should 'write for the optimizer'.

Using the wrong data types
Using Functions in Comparisons within the ON or WHERE Clause
Employing Multi-Statement User Defined Functions (UDFs)
The “Run Faster” Switch: Allowing “Dirty Reads’
Applying Query Hints indiscriminately
Allowing “Row By Agonizing Row” processing (cursos etc ...)
Indulging in Nested Views
It’s not enough that your code is readable: it must perform well too.


## Links

 https://josephmaryam.files.wordpress.com

 http://iteadjmj.com/inicio.html

## Payments
paypal.me/JesusBaizabal


GitHub Apps
Personal access tokens
Personal access tokens

Tokens you have generated that can be used to access the GitHub API.

Make sure to copy your new personal access token now. You won’t be able to see it again!
b7f16dc0ceaac172e29ca3f655a6e4ff1d9714d4


example in Gitlab
https://ambagasdowa:b7f16dc0ceaac172e29ca3f655a6e4ff1d9714d4@github.com/ambagasdowa/myrepo.git

 ## TODO

 NOTICE: Not enabling PHP 5.6 FPM by default.
NOTICE: To enable PHP 5.6 FPM in Apache2 do:
NOTICE: a2enmod proxy_fcgi setenvif
NOTICE: a2enconf php5.6-fpm
NOTICE: You are seeing this message because you have apache2 package installed.
Created symlink /etc/systemd/system/multi-user.target.wants/php5.6-fpm.service → /lib/systemd/system/php5.6-fpm.service.
Processing triggers for systemd (232-25+deb9u1) ...
